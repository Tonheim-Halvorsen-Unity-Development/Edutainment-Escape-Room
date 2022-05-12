using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool isOpened = false;
    Animator Anim;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
    }

    public void onFinish()
    {
        if (!isOpened)
        {
            isOpened = true;
            Anim.SetTrigger("DoorTrigger");
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (isOpened)
        {
            isOpened = false;
            Anim.SetTrigger("DoorTrigger");
            timer.removeOutOfTime();
        }
    }
}
