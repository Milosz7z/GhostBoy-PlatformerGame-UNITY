using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    private IEnumerator coroutine;

    void Start()
    {
        coroutine = SpawnEnemy(3.0f);
        StartCoroutine(coroutine);
    }


    private IEnumerator SpawnEnemy(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }

}
