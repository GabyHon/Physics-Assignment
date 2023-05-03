using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringScript : MonoBehaviour
{
    public enum Score
    {
        PlayerScore, AiScore
    }

    public TMP_Text AIScoreText, PlayerScoreText;

    public UIScript uiManager;

    public int MaxScore;

    // regions just for organisation
    #region Scores
    private int aiScore, playerScore;

    // create properties
    // act like fields
    // each time you get the value from them or set the value inside them
    // can calls some methods and have some code run


    private int AiScore
    {
        get { return aiScore; }
        set
        {
            // value is a keyword, implicit parameter
            aiScore = value;
            if (value == MaxScore)
                uiManager.showRestartCanvas(true);
                //levelManager.LoadLoseGameOver();
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            // value is a keyword, implicit parameter
            playerScore = value;
            if (value == MaxScore)
                uiManager.showRestartCanvas(false);
                //levelManager.LoadWinGameOver();
        }
    }
    #endregion

    // increment the scores
    public void Increment(Score whichScore)
    {
        // increment the properties AiScore and PlayerScore, not aiScore and playerScore
        // will run the get and set above
        if (whichScore == Score.AiScore)
            AIScoreText.text = (++AiScore).ToString();
        else
            PlayerScoreText.text = (++PlayerScore).ToString();
    }

    public void resetScores()
    {
        AiScore = PlayerScore = 0;
        AIScoreText.text = PlayerScoreText.text = "0";
    }
}
