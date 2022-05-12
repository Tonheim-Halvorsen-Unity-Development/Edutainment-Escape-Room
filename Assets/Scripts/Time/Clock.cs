using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public float time = 0;
    public TextMeshPro clockText;

    public BestTime BestTime;

    public GameObject test;

    public bool finished;

    private void Start()
    {
        finished = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            time += Time.deltaTime;
            TimeDisplay(time);
        }
    }

    void TimeDisplay(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void onFinish()
    {
        BestTime.checkTime(time);
        finished = true;
    }

    public void onTimeOut()
    {
        finished = true;
    }
}
