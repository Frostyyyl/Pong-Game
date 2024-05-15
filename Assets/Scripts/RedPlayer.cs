using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RedPaddle;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameRunning){
            if (Input.GetKey(KeyCode.UpArrow)){
                RedPaddle.AddForce(Vector2.up * Speed);
            } else if (Input.GetKey(KeyCode.DownArrow)){
                RedPaddle.AddForce(Vector2.down * Speed);
            }
        }
    }

    public void ResetPosition(){
        Vector2 basePosition = new(8, 0);
        RedPaddle.position = basePosition;
    }

    public void ResetVelocity(){
        RedPaddle.velocity = Vector2.zero;
    }
}
