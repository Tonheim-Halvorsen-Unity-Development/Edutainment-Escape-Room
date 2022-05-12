using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public Clock clock;
    public Timer timer;
    public ExitDoor exitDoor;
    

    public void onWin()
    {
        if (!timer.outOfTime)
        {
            clock.onFinish();
            timer.onWin();
            exitDoor.onFinish();
        }
    }
}
