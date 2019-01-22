using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    int winningScore = 5;

    [SerializeField]
    Text scoreText = null;

    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    BallControl mainBall;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainBallObj = GameObject.FindGameObjectWithTag("Ball");
        mainBall = mainBallObj.GetComponent<BallControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void Score(int playerId)
    {
        Debug.Log("Player" + playerId + "scored");
        switch(playerId)
        {
            case 1:
                PlayerScore1++;
                break;
            case 2:
                PlayerScore2++;
                break;
            default:
                Debug.LogError("Score used incorrectly");
                break;
        }
        GameObject.Find("GameManager").SendMessage("handleScore",playerId);
    }
    void handleScore(int playerId)
    {
        scoreText.text = "P1       " + PlayerScore1.ToString() + " - " + PlayerScore2.ToString() + "       P2";
        if (PlayerScore1 == winningScore)
        {
            GameOver(1);
        }
        if(PlayerScore2 == winningScore)
        {
            GameOver(2);
        }
    }

    public void updateScoreText()
    {
        scoreText.text = "P1       " + PlayerScore1.ToString() + " - " + PlayerScore2.ToString() + "       P2"; 
    }
    void displayWinner(int winner)
    {
        scoreText.text = "P " + (3-winner).ToString() + "   l05e";
    }
    void GameOver(int winner)
    {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        displayWinner(winner);
        mainBall.RestartBallGame();
    }
}
