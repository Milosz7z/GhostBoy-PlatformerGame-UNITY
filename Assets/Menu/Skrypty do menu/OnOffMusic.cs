using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffMusic : MonoBehaviour {

    private AudioSource audiosource;

    public void OnOff() {

        audiosource = GameObject.Find("MUSIC").GetComponent<AudioSource>(); // pobranie audio z gameobjectu

        if (audiosource.mute)
            audiosource.mute = false;
		else
            audiosource.mute = true;
	}
}
