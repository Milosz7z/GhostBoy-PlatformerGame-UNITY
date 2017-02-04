using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public void LoadScene(int level) //metoda do ładownia kolejnej sceny, numery do niej przekazywane są kolejnością scen w "Build Settings"
	{
		SceneManager.LoadScene(level); //ładowanie sceny
	}
}
