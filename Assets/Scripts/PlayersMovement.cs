using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D leftPaddle;
    public Rigidbody2D rightPaddle;
    private Vector2 leftPaddlePosition = new(-8, 0);
    private Vector2 rightPaddlePosition = new(8, 0);
    public float speed;

    BallMovement ballScript;
    void Start(){
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
    }
    void Update()
    {
        if (ballScript.GameRunning){
                if (Input.GetKey(KeyCode.W)){
                leftPaddle.AddForce(Vector2.up * speed);
            } else if (Input.GetKey(KeyCode.S)){
                leftPaddle.AddForce(Vector2.down * speed);
            }


            if (Input.GetKey(KeyCode.UpArrow)){
                rightPaddle.AddForce(Vector2.up * speed);
            } else if (Input.GetKey(KeyCode.DownArrow)){
                rightPaddle.AddForce(Vector2.down * speed);
            }
        }
    }

    public void ResetPaddlePositions(){
        leftPaddle.position = leftPaddlePosition;
        rightPaddle.position = rightPaddlePosition;
    }

    public void ResetPaddleVelocities(){
        leftPaddle.velocity = Vector2.zero;
        rightPaddle.velocity = Vector2.zero;
    }

}
