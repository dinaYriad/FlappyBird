using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool is_alive;
    private float upForce;

    /*
     * Script gets a reference to this variable.
     * When the game starts or when this object becomes enabled..
     * It's gonna check on the 'GameObject' (that this script is attached to) (the 'Bird') by calling this function -> "GetComponent<Rigidbody2D>();
     * If there's a "component Rigidbody2D" attached to it.
     * If there is -> It is gonna store it in this rigidbody "rb2d" variable.
     * This happens in order to do physics stuff on this "GameObject" later on.
     */
    private Rigidbody2D birdRigidBody;
    private Animator animator;

    void Start()
    {

        is_alive = true;
        upForce = 200f;

        birdRigidBody = GetComponent<Rigidbody2D>();
        animator      = GetComponent<Animator>();
    }

    void Update()
    {
        if (is_alive)
        {
            //0 for the left mouse button.
            if (Input.GetMouseButtonDown(0))
            {
                //In order to get the same effect everytime we mouse click.
                birdRigidBody.velocity = Vector2.zero;

                //No change in the x-axis. Only the y-axis.
                birdRigidBody.AddForce(new Vector2(0, upForce));

                animator.SetTrigger("Flap");
            }
        }
    }

    /*
     * From unities api.
     * Unity will always be listening for this function. 
     */
    void OnCollisionEnter2D()
    {
        birdRigidBody.velocity = Vector2.zero;
        is_alive = false;
        animator.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}