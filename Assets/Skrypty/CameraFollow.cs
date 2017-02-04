using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float dampTime = 0.15f;				//czas jaki zajmie dopasowanie kamery
	private Vector3 velocity = Vector3.zero;	//skrócona wersja Vector3(0, 0, 0).
    public Transform target;					//nasz target, tutaj podpinamy gracza 

    void Update()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			//znalezienie pozycji gracza
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			//wektor miedzy pozycją gracza i kamery
            Vector3 destination = transform.position + delta;	
			//pożądana pozycja kamery (pozycja obecna + wektor różnicy)
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			//zmiana pozycji kamery, do pozycji gracza, z opóźnienem
        }

    }
}
