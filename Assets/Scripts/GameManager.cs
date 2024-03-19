using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool timerRunning;
    void Start()
    {
        startTime = Time.time;
        timerRunning = true;
        Time.timeScale = 1.0f;

    }


    void Update()
    {
        if (timerRunning)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
    }
}
