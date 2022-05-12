using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoopManager : MonoBehaviour
{
    public GameObject key;
    public GameObject spotlight;

    [SerializeField] private int outsideState = 0; //used to keep track of which piece is put in the outside socket
    [SerializeField] private int insideState = 0; //used to keep track of which piece is put in the inside socket

    private bool showShort = false;
    private float ifTimer = 0;

    private void Start()
    {
        key.SetActive(false);
        spotlight.SetActive(false);
    }

    private void Update()
    {
        if (showShort)
        {
            ifTimer -= Time.deltaTime;
            if(ifTimer < 0)
            {
                showShort = false;
                //turn off key and light
                key.SetActive(false);
                spotlight.SetActive(false);
            }
        }
    }

    internal void outsideWhile()
    {
        outsideState = 1; //state 1 means function will run constantly, eg. key will show permanently
    }

    internal void outsideIf()
    {
        outsideState = 2; //state 2 means function will run 1 time, eg. key will show for short burst of time
    }

    internal void outsideRemoved()
    {
        outsideState = 0; //state 0 means running function will do nothing
    }
    internal void insideKey()
    {
        insideState = 1; //state 1 means the key will show depending on outside state
    }

    internal void insideLight()
    {
        insideState = 2; //state 2 means light will be turned on depending on outside state
    }

    internal void insideRemoved()
    {
        insideState = 0; //state 0 does nothing
    }

    public void ButtonPressed()
    {
        key.SetActive(false);
        spotlight.SetActive(false);
        if(outsideState != 0)
        {
            if (insideState == 1)
            {
                key.SetActive(true);
            } else if (insideState == 2)
            {
                spotlight.SetActive(true);
            }

            if (outsideState == 2)
            {
                showShort = true;
                ifTimer = 1;
            }
        }
    }
}
