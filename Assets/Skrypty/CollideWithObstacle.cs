using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithObstacle : MonoBehaviour {

	public bool touchDie = false; 	//domyślnie nie dotyka, wiec false
	public bool touchNextLevel = false;

	public GameObject Player;	//przypięty obiekt gracza 

	void Update () {

        if (touchDie)
        {   //jeśli true restart sceny	
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (touchNextLevel)
        {   //jeśli true restart sceny
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Saving.SaveData(SceneManager.GetActiveScene().buildIndex); // Zapis numeru sceny
        }
	}

	void OnCollisionEnter2D(Collision2D coll) { 	
		if (coll.gameObject.tag == "Ostrza") {		//jeśli zachodzi kolizja z tagiem "Ostrza" to zmienia się na true
			touchDie = true;
		}
        if (coll.gameObject.tag == "NextLevel")
        {       //jeśli zachodzi kolizja z tagiem "Drabina" to zmienia się na true
            touchNextLevel = true;
        }
        if (coll.gameObject.tag == "Strzala")
        {       //jeśli zachodzi kolizja z tagiem "Ostrza" to zmienia się na true
            touchDie = true;
        }
    }
}
