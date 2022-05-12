using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationEvent : MonoBehaviour
{
    bool isOpened = false;
    Animator Anim;

    bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (!isOpened)
        {
            openDoors();

        }
    }

    void openDoors()
    {
        isOpened = true;
        Anim.SetTrigger("DoorTrigger");
    }
    void OnTriggerExit(Collider other)
    {
        if (isOpened)
        {
            Invoke("closeDoors", 0.5f);
        }
    }

    void closeDoors()
    {
        isOpened = false;
        Anim.SetTrigger("DoorTrigger");
    }

}
