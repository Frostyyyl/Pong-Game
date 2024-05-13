using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ball;
    public float initialSpeed;
    public float maxSpeed;
    private bool gameRunning = false;
    private bool gameCanStart = true;
    public bool GameRunning { get => gameRunning; set => gameRunning = value; }

    PlayerMovement playerScript;

    void Start(){
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {

        if (gameCanStart && Input.GetKeyUp(KeyCode.Space)){
            gameCanStart = false;
            gameRunning = true;
            ball.velocity = Vector2.up * initialSpeed;
        }

        if (!gameRunning && Input.GetKeyUp(KeyCode.Space)){
            playerScript.ResetPaddlePositions();
            ball.position = Vector2.zero;
            gameCanStart = true;
        }


        if (gameRunning && Math.Sqrt(Math.Pow(ball.velocity.x, 2) + Math.Pow(ball.velocity.y, 2)) > maxSpeed){
            ball.velocity = ball.velocity.normalized * maxSpeed;
        }


        // Assign a new velocity if x velocity has deminished
        if (gameRunning && Math.Abs(ball.velocity.x) < 0.25){
            float currentVelocity = Math.Abs(ball.velocity.y);
            Vector2 newVelocity = new(0, 0);

            float velocityX = UnityEngine.Random.Range(0, currentVelocity);
            if (velocityX < currentVelocity / 2){
                velocityX = UnityEngine.Random.Range(-currentVelocity, -currentVelocity / 2);
            }

            // if (currentVelocity > maxSpeed / 2 && velocityX > currentVelocity / 2){
            //     velocityX = UnityEngine.Random.Range(-currentVelocity / 2, 2);
            // } else if (currentVelocity < maxSpeed / 2 && velocityX < currentVelocity / 2){
            //     velocityX = UnityEngine.Random.Range(-currentVelocity, -currentVelocity / 2);
            // }

            newVelocity.Set(velocityX, (float)Math.Sqrt(Math.Pow(currentVelocity, 2) - Math.Pow(velocityX, 2)));
            ball.velocity = newVelocity;
        }
    }
}
