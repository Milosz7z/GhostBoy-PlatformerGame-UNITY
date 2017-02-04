using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffHint : MonoBehaviour
{
    public void OnOff()
    {

        if (IfHint.IfDisplayHints)
        {
            IfHint.IfDisplayHints = false;
        }
        else
        {
            IfHint.IfDisplayHints = true;
        }
 
    }
}

public static class IfHint // klasa statyczna, która okresla, czy podpowiedzi mają się pokazywać
{
    public static bool IfDisplayHints = true; // czy podpowiedzi mają się pokazywać (skrypt działa między scenami)

}
