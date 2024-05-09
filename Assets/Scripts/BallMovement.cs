using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ball;
    public float initialSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ball.velocity = Vector2.left * initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Sqrt(Math.Pow(ball.velocity.x, 2) + Math.Pow(ball.velocity.y, 2)) > 12){
            ball.velocity = ball.velocity.normalized * maxSpeed;
        }
    }
}
