using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas; 		//Przypisanie Canvasa menu głównego
	public Canvas OptionCanvas;		//Przypisanie Canvasa opcji
	public Canvas LevelCanvas;		//Przypisanie Canvasa menu wyboru poziomów

    void Awake() //na początku wyłączone Canvasy, później analogicznie
    {
        OptionCanvas.enabled = false;
		LevelCanvas.enabled = false;
    }

    public void OptionsOn()
    {
        OptionCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

	public void LevelsOn()
	{
		LevelCanvas.enabled = true;
		MainCanvas.enabled = false;
	}

    public void ReturnMain()
    {
        OptionCanvas.enabled = false;
		LevelCanvas.enabled = false;
        MainCanvas.enabled = true;
    }
}
