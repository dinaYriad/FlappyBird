using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If casting succeeded and it is actually a bird.
        if (collision.GetComponent<Bird>() != null)
        {
            GameController.instance.BirdScored();
        }
    }
}
