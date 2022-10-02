using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    private float inputX,inputY;
    private float stopX,stopY;

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(inputX,inputY).normalized;
        rb.velocity = input * speed;

        if (input != Vector2.zero )
        {
            animator.SetBool("isMoving",true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving",false);
        }
        animator.SetFloat("InputX",stopX);
        animator.SetFloat("InputY",stopY);
    }
}
