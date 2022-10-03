using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooter : MonoBehaviour
{   
    public float interval;
    public float timer;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 200f;
    public Camera cam;
    Vector3 mousePos;
    public Transform FireTransform;
    
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
        Fire();
    }

     void FixedUpdate()
    {
       Vector3 target = (mousePos - transform.position).normalized;
       float angle = Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg - 90f;
       FireTransform.eulerAngles = new Vector3(0,0,angle);
    }

    void Fire()
    {
        if(timer != 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                timer = 0;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (timer == 0)
            {
                Shoot();
                timer = interval;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,FirePoint.position,FirePoint.rotation);
        bullet.GetComponent<Bullet>().InitBullet(FirePoint.up * bulletForce, EBulletType.hitEnemy);
    }
}
