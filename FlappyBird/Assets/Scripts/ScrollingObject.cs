using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    void Start()
    {
        //Saves a reference to the rigidbody that is attached to this script inside this "rigidBody" variable.
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(GameController.instance.scrollingSpeed, 0);
    }

    void Update()
    {
        if (GameController.instance.is_gameOver)
            rigidBody.velocity = Vector2.zero;
    }
}
