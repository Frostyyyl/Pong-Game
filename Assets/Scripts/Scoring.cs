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
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI winnerInfo;
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
                Debug.Log("Red " + rightPoints);
                rightText.SetText(rightPoints.ToString());
                
                if (rightPoints == pointsToWin){
                    winnerInfo.SetText("Red Won!");
                    ballScript.GameEnded = true;
                }
            } else if (gameObject.name == "RightGoal"){
                leftPoints += 1;
                Debug.Log("Blue " + leftPoints);
                leftText.SetText(leftPoints.ToString());
                
                if (leftPoints == pointsToWin){
                    winnerInfo.SetText("Blue Won!");
                    ballScript.GameEnded = true;
                }
            }
        }
    }

    public void ResetPoints(){
        leftPoints = 0;
        rightPoints = 0;
    }
}
