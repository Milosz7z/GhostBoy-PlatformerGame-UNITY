using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHints : MonoBehaviour {

    private GameObject[] hints;

    // Use this for initialization
    void Start () {
        hints = GameObject.FindGameObjectsWithTag("Hint"); // wyszukanie obiektów, które są podpowiedzią (do tablicy)

        foreach (GameObject hint in hints) // pętla odpowiada za ukrycie/pokazanie podpowiedzi
        {
            if (IfHint.IfDisplayHints == true)
            {
                hint.SetActive(true);
            }
            else
            {
                hint.SetActive(false);
            }
            
        }
    }
}
