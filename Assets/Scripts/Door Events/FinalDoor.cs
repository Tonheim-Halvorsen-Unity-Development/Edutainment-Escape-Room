using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    bool isOpened = false;
    private bool canOpen = false;
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider col)
    {
        if (!isOpened)
        {
            if (canOpen)
            {
                isOpened = true;
                Anim.SetTrigger("DoorTrigger");
            }
        }
    }

    internal void inside()
    {
        canOpen = false;
    }

    public void openFinalDoor()
    {
        canOpen = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (isOpened)
        {
            isOpened = false;
            Anim.SetTrigger("DoorTrigger");
        }
    }
}
