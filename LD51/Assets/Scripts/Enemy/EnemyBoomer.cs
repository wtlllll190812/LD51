using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBoomer : EnemyBase
{

    private  static readonly int BoomString = Animator.StringToHash("Boom");
    protected override void Find()
    {
        if (target!=null&&Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            aIPath.maxSpeed = 0;
            Attack();
        }
    }
    protected override void Attack()
    {
        animator.Play(BoomString);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //TODO Ôì³ÉÉËº¦

        }
    }
    protected override void ChangeDirction()
    {
        if (aIPath.desiredVelocity.x >= 1e-3f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
