using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public enum EBulletType
{
    hitEnemy,
    hitPlayer,
    both
}

public class Bullet : MonoBehaviour
{
    public Color colorOnBoth;
    public Color colorOnHitPlayer;
    public Color colorOnHitEnemy;

    private Vector3 lastPoint;
    private Rigidbody2D rbody;
    private EBulletType _bulletType;

    private EBulletType bulletType
    {
        set
        {
            switch (value)
            {
                case EBulletType.hitPlayer:
                    GetComponent<SpriteRenderer>().color = colorOnHitPlayer;
                    break;
                case EBulletType.hitEnemy:
                    GetComponent<SpriteRenderer>().color = colorOnHitEnemy;
                    break;
                case EBulletType.both:
                    GetComponent<SpriteRenderer>().color = colorOnBoth;
                    break;
                default:
                    break;
            }
            _bulletType = value;
        }
        get => _bulletType;
    }



    void Start()
    {
        rbody=GetComponent<Rigidbody2D>();
        InitBullet(Vector2.down, EBulletType.hitEnemy);
    }

    [Button("StartMove")]
    public void InitBullet(Vector2 force,EBulletType type)
    {
        rbody.AddForce(force, ForceMode2D.Impulse);
        lastPoint = transform.position;
        bulletType = type;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BounceBoard"))
        {
            bulletType = EBulletType.both;
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
