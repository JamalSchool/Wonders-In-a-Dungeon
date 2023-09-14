using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public int speed = 5; // can change the speed in unity eventhough it's a private variable.
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // assigns the rigid body variable to the existing 2D rigid body in unity 
                                          // get component whose type is defined between the angle brackets

        animator = GetComponent<Animator>();
    }




    private void OnMovement(InputValue value) 
    {
        movement = value.Get<Vector2>(); // get the recent value on the keyboard and will do the actions such as W as to move forward so the coordinates will go to ( 0,1)
        if(movement.x!=0 || movement.y!=0) // makes the animation not always go to the idledown position when you stop moving.
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool ("IsMoving", false);
        }
        
    }

    private void FixedUpdate() // better use for phyiscs based characters such as rigid body
    {
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); // calculates the position by initial pos + the direction you want to move in.
    }
}
