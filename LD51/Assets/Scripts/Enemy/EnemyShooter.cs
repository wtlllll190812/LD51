using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyBase
{
    public GameObject BulletPrefab;
    public float attackInterval=2f;
    public float bulletForce=200f;
    private float timer;
    public Transform shooter;

    private void FixedUpdate()
    {
        Vector3 _target = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(_target.y, _target.x) * Mathf.Rad2Deg - 90f;
        shooter.eulerAngles = new Vector3(0, 0, angle);
    }
    protected override void Attack()
    {
        timer += Time.deltaTime;
        if (timer > attackInterval)
        {
            GameObject bullet = Instantiate(BulletPrefab, shooter.position , shooter.rotation);
            bullet.GetComponent<Bullet>().InitBullet(shooter.up * bulletForce, EBulletType.hitPlayer);
            timer = 0;
        }
    }
}
