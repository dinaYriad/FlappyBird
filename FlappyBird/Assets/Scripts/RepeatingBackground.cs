﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundLength;

    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundLength = groundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -groundLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}