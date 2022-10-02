using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float intervalTimer;
    public float mapSizeX;
    public float mapSizeY;

    private float timer;
    private void Start()
    {
        timer = 0f;

    }
    private void Update()
    {
         timer += Time.deltaTime;
        if (timer >= intervalTimer)
        {
            Vector3 randomPosition = new Vector3(Random.Range(0, mapSizeX), Random.Range(0f, mapSizeY), 0f);
            var newObj=Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], randomPosition, Quaternion.identity);
            newObj.transform.SetParent(transform);
            timer = 0;
        }

    }

}
