using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    BallMovement ballScript;
    PlayerMovement playerScript;

    public int pointsToWin = 3;
    private int leftPoints;
    private int rightPoints;

    void Start(){
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject){
            ballScript.GameRunning = false;
            ballScript.ball.velocity = Vector2.zero;
            playerScript.ResetPaddleVelocities();
            if (gameObject.name == "LeftGoal"){
                rightPoints += 1;
                if (rightPoints == pointsToWin){
                    Debug.Log("Right Won!");
                }
            } else {
                leftPoints += 1;
                if (leftPoints == pointsToWin){
                    Debug.Log("Left Won!");
                }
            }
        }
    }
}
