using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBase : MonoBehaviour
{
    public AIDestinationSetter setter;
    public Animator animator;
    public AIPath aIPath;
    public float attackRange;
    public float Maxspeed=2f;
    public Transform target;

    public void Start()
    {
        setter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        aIPath.maxSpeed = Maxspeed;
        target = setter.target.transform;
    }

    public void Update()
    {
        ChangeDirction();
        Find();
        
    }

    protected virtual void Find()
    {
        if (target != null)
        {

            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                aIPath.maxSpeed = 0;
                Attack();
            }
            else if (Vector3.Distance(transform.position, target.position) > attackRange)
            {
                aIPath.maxSpeed = Maxspeed;
            }
        }
    }
    protected virtual void Attack()
    {
        //TODO ¶¯»­
        //TODO ÉËº¦¼ì²â
    }

     protected  virtual  void ChangeDirction()
    {
        if(aIPath.desiredVelocity.x>=1e-3f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
