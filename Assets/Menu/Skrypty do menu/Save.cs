using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour {
	
}

public static class Saving
{
    private static int scene;

    public static void SaveData(int _scene)
    {
        BinaryFormatter bf = new BinaryFormatter(); // konwersja binarna
        FileStream file = File.Create(Application.persistentDataPath + "/SceneData.dat"); //tworzenie pliku

        SceneData data = new SceneData(); // nowy obiekt SceneData
        data.scene = _scene; // przypisanie argumentu metody do obiektu SceneData

        bf.Serialize(file, data); // serializacja
        file.Close();
    }

    public static int LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/SceneData.dat")) //sprawdzenie czy plik istnieje
        {
            BinaryFormatter bf = new BinaryFormatter(); // konwersja binarna
            FileStream file = File.Open(Application.persistentDataPath + "/SceneData.dat", FileMode.Open); // otwarcie pliku
            SceneData data = (SceneData)bf.Deserialize(file); // deserializacja
            file.Close();

            return data.scene; // zwrot numeru sceny
        }
        return 0;
    }

}

[Serializable]
class SceneData {
    public int scene;
}
