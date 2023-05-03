using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class decreaseScore : MonoBehaviour
{
    bool wasHit = false;
    bool curentlycolliding = false;

    public enum Score
    {
        PlayerScore, AiScore
    }

    public TMP_Text AIScoreText, PlayerScoreText;

    private int aiScore, playerScore;


    private int AiScore
    {
        get { return aiScore; }
        set
        {
            // value is a keyword, implicit parameter
            aiScore = value;
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            // value is a keyword, implicit parameter
            playerScore = value;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // checking if the paddle (player or AI) has hit the puck
        if (collision.gameObject.CompareTag("Puck") && curentlycolliding == false && wasHit == false)
        {
            wasHit = true;
            curentlycolliding = true;
        }
        // checking if the puck was already hit and then subsequently decrementing the score
        else if (collision.gameObject.CompareTag("Puck") && curentlycolliding == false && wasHit == true)
        {
            AIScoreText.text = (-AiScore).ToString();
            PlayerScoreText.text = (-PlayerScore).ToString();
        }
    }

    /*public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
            AIScoreText.text = (-AiScore).ToString();
        else
            PlayerScoreText.text = (-PlayerScore).ToString();
    }*/

    // checking if the puck is colliding with the paddle, if it is, the colliding is false, resetting, when exiting collision
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Puck" && curentlycolliding == true)
        {
            wasHit = false;
            curentlycolliding = false;
        }
    }

}
