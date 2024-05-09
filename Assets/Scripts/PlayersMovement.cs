using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D leftPaddle;
    public Rigidbody2D rightPaddle;
    public float speed;

    void Update()
    {
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
