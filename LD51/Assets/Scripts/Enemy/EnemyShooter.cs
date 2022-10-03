using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    public GameObject BulletPrefab;
    public float attackInterval=2f;
    private float timer;
    public Transform shooter;

    protected override void Attack()
    {
        timer += Time.deltaTime;
        if (timer > attackInterval)
        {
            //Éú³É×Óµ¯
            
            timer = 0;
        }
    }
}
