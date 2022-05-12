using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public ExitDoor exitDoor;
    public float timeCountdown = 180;
    public TextMeshProUGUI timerText;
    public bool StartTimer = false;
    [SerializeField] private AudioSource myAudio;
    private bool gameDone;
    public int oneTimeEvent = 1;

    public Clock clock;

    public GameObject tempOutOfTime;

    public bool outOfTime = false;

    public void Start()
    {
        tempOutOfTime.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer == true && !gameDone)
        {
            if (timeCountdown > 0)
            {
                timeCountdown -= Time.deltaTime;
            }
            else
            {
                if(!outOfTime)
                {
                    timeCountdown = 0;
                    onOutOfTime();
                }
            }
        }
        TimeDisplay(timeCountdown);
    }

    internal void removeOutOfTime()
    {
        tempOutOfTime.SetActive(false);
    }

    private void onOutOfTime()
    {
        tempOutOfTime.SetActive(true);
        outOfTime = true;
        clock.onTimeOut();
        exitDoor.onFinish();
    }

    void TimeDisplay(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void OnTriggerEnter(Collider other)
    {
        StartTimer = true;
        
        if (oneTimeEvent == 1)
        {
            myAudio.Play();
            oneTimeEvent += 1;
        }
    }

    public void onWin()
    {
        gameDone = true;
    }
}
