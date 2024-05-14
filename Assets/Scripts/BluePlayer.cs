using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D BluePaddle;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameRunning){
            if (Input.GetKey(KeyCode.W)){
                BluePaddle.AddForce(Vector2.up * Speed);
            } else if (Input.GetKey(KeyCode.S)){
                BluePaddle.AddForce(Vector2.down * Speed);
            }
        }
    }

    public void ResetPosition(){
        Vector2 basePosition = new(-8, 0);
        BluePaddle.position = basePosition;
    }

    public void ResetVelocity(){
        BluePaddle.velocity = Vector2.zero;
    }
}
