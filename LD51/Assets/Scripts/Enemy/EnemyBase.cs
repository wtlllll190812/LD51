using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyBase : MonoBehaviour
{
    protected AIDestinationSetter setter;
    public float attackRange;
    public Vector3 target;

    public void Start()
    {
        setter = GetComponent<AIDestinationSetter>();
        target = setter.target.position;
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, target) <= attackRange)
        {
            transform.GetComponent<AIDestinationSetter>().enabled = false;
            transform.GetComponent<AIPath>().enabled = false;
            Attack();

        }
    }
    protected virtual void Attack()
    {
        //TODO ∂Øª≠
        //TODO …À∫¶ºÏ≤‚
    }
}
