using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountDown : MonoBehaviour
{
    public GameObject TimerCanvas;
    public GameObject GameCanvas;
    public GameObject PaddlesAndPucks;

    public float currentTime = 0f;
    public float startingTime = 3f;

    [SerializeField]
    public TMP_Text TimerDisplay;

    void Start()
    {
        currentTime = startingTime;
    }

    public void Update()
    {
        GameCanvas.SetActive(false);
        TimerCanvas.SetActive(true);
        PaddlesAndPucks.SetActive(false);

        //decreasing timer by 1, but every second instead of every frame
        currentTime -= 1 * Time.deltaTime;
        TimerDisplay.text = currentTime.ToString("0");

        TimerDisplay.color = Color.cyan;

        // stopping timer after 0
        if (currentTime <= 0)
        {
            currentTime = 0;
            GameCanvas.SetActive(true);
            TimerCanvas.SetActive(false);
            PaddlesAndPucks.SetActive(true);
        }
    }

}
