using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saved : MonoBehaviour {

    public void loadSavedLevels()
    {
        if (Saving.LoadData() >= 0 && Saving.LoadData() <= 4) { // numer sceny pasuje do gry
            for (int i = Saving.LoadData() + 1; i <= 4; i++) // pętla dezaktywuje levele, które nie zostały skończone
            {
                GameObject.Find("Level" + i + "Done").SetActive(false); // dezaktywacja gameobjectu
            }
        }
        else // jeśli numer sceny nie pasuje, wszystko ma się zdezaktywować
        {
            for (int i = 1; i <= 4; i++)
            {
                GameObject.Find("Level" + i + "Done").SetActive(false);
            }
        }
    }
}
