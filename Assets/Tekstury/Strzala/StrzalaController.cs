using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrzalaController : MonoBehaviour
{
    public bool touchDie = false;
    public bool Prawo = true;
    public float Predkosc = 25f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Prawo)
        {
            transform.Translate(Vector2.right * Predkosc * Time.deltaTime);
        }
        else
        {
            transform.Translate(-1 * Vector2.right * Predkosc * Time.deltaTime);
        }

        if (touchDie)   //jeśli true restart sceny	
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroyer") //po dotknieciu collidera z tagiem destroyer strzala zostaje zniszczona
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")  //po dotknieciu gracza touchdie zmienia sie na true i zachodzi ponowne wczytanie aktualnej sceny
        {       
            touchDie = true;
        }
    }
}
