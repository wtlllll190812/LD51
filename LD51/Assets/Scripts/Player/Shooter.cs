using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 200f;
    public Camera cam;
    Vector3 mousePos;
    public Transform FireTransform;
    
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); 
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

     void FixedUpdate()
    {
       Vector3 target = (mousePos - transform.position).normalized;
       float angle = Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg - 90f;
       FireTransform.eulerAngles = new Vector3(0,0,angle);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,FirePoint.position,FirePoint.rotation);
        Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
        rb2D.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }

   
}
