using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject Player;
    public float intervalTimer;
    public float mapSizeX;
    public float mapSizeY;

    private float MinInterval;
    private float timer;
    private void Start()
    {
        timer = 0f;
        Player = GameObject.Find("Player");
        MinInterval = 0.5f;
    }
    private void Update()
    {
         timer += Time.deltaTime;
        intervalTimer = intervalTimer<=0.5f?MinInterval:intervalTimer - GameManager.instance.GameTimer / 100f*Time.deltaTime;
        if (timer >= intervalTimer&&Player!=null)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-mapSizeX, mapSizeX), Random.Range(-mapSizeY, mapSizeY), 0f);
            var newObj=Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], randomPosition, Quaternion.identity);
            newObj.transform.SetParent(transform);
            timer = 0;
        }

    }

}
