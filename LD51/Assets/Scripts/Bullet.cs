using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public enum EBulletType
{ 
    hitPlayer,
    hitEnemy,
    both
}

public class Bullet : MonoBehaviour
{
    private Vector3 lastPoint;
    private Rigidbody2D rbody;
    private EBulletType bulletType;

    void Start()
    {
        rbody=GetComponent<Rigidbody2D>();
        StartMove(Vector2.down, EBulletType.both);
    }

    [Button("StartMove")]
    public void StartMove(Vector2 force,EBulletType type)
    {
        ChangeType(type);
        rbody.AddForce(force, ForceMode2D.Impulse);
        lastPoint = transform.position;
    }

    public void ChangeType(EBulletType type)
    {
        bulletType = type;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BounceBoard"))
        {
            Vector2 inVec = transform.position - lastPoint;
            lastPoint = transform.position;
            Vector2 outVec = Vector2.Reflect(inVec, collision.contacts[0].normal);
            rbody.velocity = outVec.normalized * 1;
        }
        if (collision.gameObject.CompareTag("Player") && bulletType != EBulletType.hitEnemy)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && bulletType != EBulletType.hitPlayer)
        {
            Destroy(collision.gameObject);
        }
    }
}
