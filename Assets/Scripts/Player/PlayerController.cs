using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2( moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;
        Debug.Log("Velocity: "+ rb2d.velocity);
    }
}
