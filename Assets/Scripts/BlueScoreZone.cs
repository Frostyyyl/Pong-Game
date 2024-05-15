using UnityEngine;

public class BlueScoreZone : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject){
            gameManager.RedScores();
        }
    }
}
