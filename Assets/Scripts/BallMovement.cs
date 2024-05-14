using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D Ball;
    public float InitialSpeed;
    public float MaxSpeed;

    private float minSpeed = 0.25f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameRunning){
            if (Math.Sqrt(Math.Pow(Ball.velocity.x, 2) + Math.Pow(Ball.velocity.y, 2)) > MaxSpeed){
            Ball.velocity = Ball.velocity.normalized * MaxSpeed;
            }

            // Assign a new velocity if x velocity has deminished
            if (Math.Abs(Ball.velocity.x) < minSpeed){
                Vector2 newVelocity = new(0, 0);
                float curVelocity = Math.Abs(Ball.velocity.y);

                float xVelocity = UnityEngine.Random.Range(0, curVelocity);
                if (xVelocity < curVelocity / 2){
                    xVelocity = UnityEngine.Random.Range(-curVelocity, -curVelocity / 2);
                }

                newVelocity.Set(xVelocity, (float)Math.Sqrt(Math.Pow(curVelocity, 2) - Math.Pow(xVelocity, 2)));
                Ball.velocity = newVelocity;
            }
        }   
    }

    public void SetVelocity(){
        Ball.velocity = Vector2.up * InitialSpeed;
    }

    public void ResetVelocity(){
        Ball.velocity = Vector2.zero;
    }

    public void ResetPosition(){
        Ball.position = Vector2.zero;
    }
}
