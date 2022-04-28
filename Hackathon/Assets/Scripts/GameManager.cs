using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ParticleSystem snow;
    public ParticleSystem heavySnow;
    
    public float rescueTime = 1000;

    public bool isStormHappened = false;

    public TMP_Text timerText;

    private void Awake()
    {
        UpdateTimer();
    }

    private void Update()
    {
        if (isStormHappened)
        {
            snow.gameObject.SetActive(false);
            heavySnow.gameObject.SetActive(true);
        }
    }

    public void UpdateTimer()
    {
        int hour = Mathf.FloorToInt(rescueTime / 60);
        float minute = rescueTime % 60;

        if (hour.ToString().Length < 2)
        {
            if (minute.ToString().Length < 2)
            {
                timerText.text = "0" + hour + ":0" + minute;
            }
            else
            {
                timerText.text = "0" + hour + ":" + minute;
            }
        }
        else
        {
            if (minute.ToString().Length < 2)
            {
                timerText.text = hour + ":0" + minute;
            }
            else
            {
                timerText.text = hour + ":" + minute;
            }
        }
    }

    public void goNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
