using UnityEngine;

public class UIScript : MonoBehaviour
{
    [Header("Game")]
    public GameObject GameCanvas;
    public GameObject WinOrLoseCanvas;

    [Header("Restart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

   [Header("Other")]
    public ScoringScript scoreScript;
    public puckScript Puckscript;
    public playerMovement Playermovement;
    public AImovement aiScript;

    public void showRestartCanvas(bool didAIWin)
    {
        Time.timeScale = 0;

        GameCanvas.SetActive(false);
        WinOrLoseCanvas.SetActive(true);

        if (didAIWin)
        {
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }  
    
    public void restartGame()
    {
        Time.timeScale = 1;

        GameCanvas.SetActive(true);
        WinOrLoseCanvas.SetActive(false);

        Playermovement.ResetPosition();
        aiScript.ResetPos();

        scoreScript.resetScores();
        Puckscript.RecentrePuck();
    }
}