using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ball;
    public float initialSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ball.velocity = Vector2.up * initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Sqrt(Math.Pow(ball.velocity.x, 2) + Math.Pow(ball.velocity.y, 2)) > maxSpeed){
            ball.velocity = ball.velocity.normalized * maxSpeed;
        }


        // Assign a new velocity if x velocity has deminished
        if (Math.Abs(ball.velocity.x) < 0.25){
            float currentVelocity = ball.velocity.y;
            Vector2 newVelocity = new(0, 0);

            float velocityX = UnityEngine.Random.Range(2, currentVelocity);
            if (currentVelocity > maxSpeed / 2 && velocityX > currentVelocity / 2){
                velocityX = UnityEngine.Random.Range(-currentVelocity / 2, 2);
            } else if (currentVelocity < maxSpeed / 2 && velocityX < currentVelocity / 2){
                velocityX = UnityEngine.Random.Range(-currentVelocity, -currentVelocity / 2);
            }

            newVelocity.Set(velocityX, (float)Math.Sqrt(Math.Pow(currentVelocity, 2) - Math.Pow(velocityX, 2)));
            ball.velocity = newVelocity;
        }
    }
}
