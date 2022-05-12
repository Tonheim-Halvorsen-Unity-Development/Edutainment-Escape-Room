using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BestTime : MonoBehaviour
{
    public static float bestTime = 0;
    public TextMeshPro bestTimeText;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Hub")
        {
            TimeDisplay(bestTime);
        }
    }


    public void checkTime(float newTime)
    {
        if (newTime < bestTime || bestTime == 0)
        {
            bestTime = newTime;
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
        bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

