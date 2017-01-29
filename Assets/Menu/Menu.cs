using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas OptionCanvas;
	public Canvas LevelCanvas;

    void Awake()
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
