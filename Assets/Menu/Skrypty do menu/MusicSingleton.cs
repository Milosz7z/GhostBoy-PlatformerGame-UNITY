using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour {

	public GameObject musicPlayer;
	void Awake() {
        //DontDestroyOnLoad(musicPlayer);
        //Kiedy scena się ładuje sprawdza czy jest obiekt o nazwie "MUSIC"
        musicPlayer = GameObject.Find("MUSIC");

        if (musicPlayer == null)
        {
            //Jeśli nawiązanie do obiektu nie istnieje:
            //1. Wiąże obiekt ze skryptu z musicPlayer
            musicPlayer = this.gameObject;
            //2. Zmienia nazwę THIS obiektu na "MUSIC" 
            musicPlayer.name = "MUSIC";
            //3. Obiekt się nie niszczy po zmianie sceny.
            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (this.gameObject.name != "MUSIC")
            {
                //Jeśli na scenie był obiekt o nazwie "MUSIC" (ponieważ wracamy do
                //sceny gdzie muzyka się zaczynała) wtedy mówi temu obiektowi 
                //żeby się zniszczył jeśli nie jest pierwotnym.
                Destroy(this.gameObject);
            }
        }
    }
}
