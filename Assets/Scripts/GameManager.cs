using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameReady = true;
    private bool gameRunning = false;
    private bool gameEnded = false;
    private bool textDisplayed = true;
    private int blueScore;
    private int redScore;

    public bool GameRunning { get => gameRunning; set => gameRunning = value; }

    public TextMeshProUGUI textInfo;
    public TextMeshProUGUI winnerInfo;
    public TextMeshProUGUI bluePoints;
    public TextMeshProUGUI redPoints;
    public int WinningScore;

    public AudioSource pointSound;

    private BluePlayer bluePlayer;
    private RedPlayer redPlayer;
    private BallMovement ballMovement;

    // Start is called before the first frame update
    void Start(){
        bluePlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<BluePlayer>();
        redPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<RedPlayer>();
        ballMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }

        if (gameReady && Input.GetKeyUp(KeyCode.Space)){
            gameReady = false;
            if (textDisplayed){
                textDisplayed = false;
                textInfo.enabled = false;
            }
            gameRunning = true;
            ballMovement.SetVelocity();
        }

        if (!gameRunning && Input.GetKeyUp(KeyCode.Space)){
            bluePlayer.ResetPosition();
            redPlayer.ResetPosition();
            ballMovement.ResetPosition();
            if (gameEnded){
                gameEnded = false;
                winnerInfo.SetText("");
                ResetScores();
            }
            gameReady = true;
        }
    }

    void ResetScores(){
        blueScore = 0;
        redScore = 0;
        bluePoints.SetText("0");
        redPoints.SetText("0");
    }

    void StopGame(){
        gameRunning = false;
        ballMovement.ResetVelocity();
        bluePlayer.ResetVelocity();
        redPlayer.ResetVelocity();
    }

    public void RedScores(){
		pointSound.Play();
        StopGame();
        redScore += 1;
        redPoints.SetText(redScore.ToString());
        if (redScore == WinningScore){
            winnerInfo.SetText("Purple Won!");
            gameEnded = true;
        }
    }

    public void BlueScores(){
        pointSound.Play();
        StopGame();
        blueScore += 1;
        bluePoints.SetText(blueScore.ToString());
        if (blueScore == WinningScore){
            winnerInfo.SetText("Pink Won!");
            gameEnded = true;
        }
    }
}
