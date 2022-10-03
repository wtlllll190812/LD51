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
    [ColorUsageAttribute(true, true)] public Color colorOnBoth;
    [ColorUsageAttribute(true, true)] public Color colorOnHitPlayer;
    [ColorUsageAttribute(true, true)] public Color colorOnHitEnemy;

    private Vector3 lastPoint;
    private Rigidbody2D rbody;
    private EBulletType _bulletType;
    private float force;

    private EBulletType bulletType
    {
        set
        {
            switch (value)
            {
                case EBulletType.hitPlayer:
                    GetComponent<SpriteRenderer>().color = colorOnHitPlayer;
                    gameObject.layer = 8;
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

    public void Update()
    {
        if(Vector3.Distance(transform.position,Vector3.zero)>20)
            Destroy(gameObject);
    }

    [Button("StartMove")]
    public void InitBullet(Vector2 force,EBulletType type)
    {
        rbody=GetComponent<Rigidbody2D>();
        rbody.AddForce(force, ForceMode2D.Impulse);
        lastPoint = transform.position;
        bulletType = type;
        this.force = force.magnitude;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BounceBoard"))
        {
            if (collision.gameObject.GetComponent<BounceBoard>().isActive)
                Destroy(gameObject);
            bulletType = EBulletType.both;
            Vector2 inVec = transform.position - lastPoint;
            lastPoint = transform.position;
            Vector2 outVec = Vector2.Reflect(inVec, collision.contacts[0].normal).normalized;
            rbody.AddForce(force* outVec, ForceMode2D.Impulse);
            float angle = Mathf.Atan2(outVec.y, outVec.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        if (collision.gameObject.CompareTag("Player") && bulletType != EBulletType.hitEnemy)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && bulletType != EBulletType.hitPlayer)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
