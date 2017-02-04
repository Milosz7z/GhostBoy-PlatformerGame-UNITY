using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float MaxSpeed = 10f; // maksymalna predkosc
    [SerializeField]
    private float JumpForce = 800f; // sila skoku
    [Range(0, 1)]
    [SerializeField]
    private float MoveSpeed = .7f; // predkosc ruchu
    [SerializeField]
    private bool AirControl = true; // kontrola playera w powietrzu
    [SerializeField]
    private LayerMask WhatIsGround; // określenie, który Layer jest ziemią

    private Transform GroundCheck; // tranform od gameobjectu GroundCheck
    const float GroundedRadius = .2f; // okrąg, który jest częścią GroundCheck i sprawdza większe pole
    private bool Grounded; // czy player jest na ziemi
    private Animator Anim;
    private Rigidbody2D Rigidbody2D;

    private bool Glued = false; // czy player jest przyklejony
    private string Glued_Position = null; // pozycja przyklejenia lewo/prawo

    private float h = 0f; // wartość od klawiszy lewo/prawo

    private bool Jump; // czy player ma skoczyć


    private void Awake()
    {
        GroundCheck = transform.Find("GroundCheck"); // wyszukanie gameobjectu GroundCheck
        Anim = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Glued_Position = null;
        Rigidbody2D.freezeRotation = true; // zablokowanie rotacji playera
    }

    private void Update()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector2.up); // zablokowanie rotacji playera
        if (!Jump) // sprawdzenie, czy gracz wciska spację
        {
            Jump = Input.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        Rigidbody2D.freezeRotation = true; // zablokowanie rotacji
        h = Input.GetAxisRaw("Horizontal"); // pobranie wartości wciskanych klawiszy lewo/prawo
        Move(h, Jump); // metoda odpowiedzialna za ruch playera
        Jump = false;
        Grounded = false;
        // funkcjonalność, która sprawdza, czy player jest na ziemi
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround); // lista wszystkich colliderow w odrębie okręgu
        for (int i = 0; i < colliders.Length; i++) // pętla z colliderami
        {
            if (colliders[i].gameObject != gameObject)
                Grounded = true;
        }
    }


    public void Move(float move, bool jump)
    {
        if (Grounded || AirControl) // jeśli player jest na ziemi i ma możliwość ruchu w powietrzu
        {
            move *= MoveSpeed; // przypisywanie predkosci ruchu
            Rigidbody2D.velocity = new Vector2(move * MaxSpeed, Rigidbody2D.velocity.y); // ruch gracza

            if (h > 0) // jeśli gracz wciska strzałkę w prawo
            {
                Anim.SetBool("IdleLeft", false);
                Anim.SetBool("IdleRight", true);

            }
            else if (h < 0) // jeśli gracz wciska strzałkę w lewo
            {
                Anim.SetBool("IdleRight", false);
                Anim.SetBool("IdleLeft", true);

            }
            else if (h == 0) // jeśli gracz nie wciska ani strzałki w lewo, ani w prawo
            {
                Anim.SetBool("IdleRight", false);
                Anim.SetBool("IdleLeft", false);
            }
        }

        if (Grounded) // jeśli player jest na ziemi
        {
            Glued = false;
            Anim.SetBool("Jump", false);
        }


        if (Grounded && jump && Glued_Position == null) // jeśli player jest na ziemi, chce skoczyć i nie jest przyklejony do sciany
        {
            Grounded = false;
            Glued = false;
            Rigidbody2D.AddForce(new Vector2(0f, JumpForce));
            Anim.SetBool("Jump", true);
        }

        if (Glued && jump && Glued_Position == "right" && h > 0f && !Grounded) // jeśli player nie jest na ziemi, chce skoczyć i jest przyklejony do lewej sciany
        {
            Grounded = false;
            Glued = false;
            Rigidbody2D.AddForce(new Vector2(1000f, JumpForce));
        }

        if (Glued && jump && Glued_Position == "left" && h < 0f && !Grounded) // jeśli player nie jest na ziemi, chce skoczyć i jest przyklejony do prawej sciany
        {
            Grounded = false;
            Glued = false;
            Rigidbody2D.AddForce(new Vector2(-1000f, JumpForce));
        }


        if (Glued) // jeśli player jest przyklejony do ściany
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX; // zablokowanie X
            Rigidbody2D.gravityScale = 0.4f; // zmniejszenie grawitacji
            Rigidbody2D.mass = 0.4f; // zmniejszenie masy
            
            // zmiana skali Z, zeby player mógł powoli spadać na ziemię (feature bug)
            Vector3 theScale = transform.localScale;
            theScale.z *= -1;
            transform.localScale = theScale; 
        }
        else
        {
            Rigidbody2D.constraints = RigidbodyConstraints2D.None; // odblokowanie X
            Rigidbody2D.gravityScale = 3f; // normalna grawitacja
            Rigidbody2D.mass = 1f; // normalna masa
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall") // jeśli player styka się ze ścianą
        {
            if (transform.position.x > coll.transform.position.x) // sprawdzenie, po której stronie ściany jest player
            {
                Glued_Position = "right";
            }
            else
            {
                Glued_Position = "left";
            }

        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall") // jeśli player styka się ze ścianą
        {
            Glued = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall") // jeśli player przestaje stykać się ze ścianą
        {
            Glued = false;
            Glued_Position = null;
        }
    }
}
