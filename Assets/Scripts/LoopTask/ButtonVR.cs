using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("hand"))
        onPress.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onRelease.Invoke();
    }
}
