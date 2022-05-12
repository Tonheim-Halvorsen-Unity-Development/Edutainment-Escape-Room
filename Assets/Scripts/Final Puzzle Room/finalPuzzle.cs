using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    private bool firstPartDone = false;

    private int firstPart = 0;
    private int secondPart = 0;

    public GameObject firstPartText;
    public GameObject secondPartText;
    public GameObject code;

    public GameObject pictures;

    public GameObject blocks1;
    public GameObject blocks2;
    public GameObject blocks3;

    //legg inn final puzzle teksten;

    void Start()
    {
        blocks1.SetActive(false);
        blocks2.SetActive(false);
        blocks3.SetActive(false);
    }

    private void Update()
    {
        if (firstPart <= 0)
        {
            firstPartDone = true;
        }
        if (firstPartDone)
        {
            firstPartText.SetActive(false);
            pictures.SetActive(false);

            secondPartText.SetActive(true);
            blocks1.SetActive(true);
            blocks2.SetActive(true);
            blocks3.SetActive(true);
        }
        if (secondPart >= 3)
        {
            secondPartText.SetActive(false);
            code.SetActive(true);
        }
    }

    internal void decrementFirstPart()
    {
        firstPart--;
    }

    internal void incrementFirstPart()
    {
        firstPart++;
    }

    internal void incrementSecondPart()
    {
        secondPart++;
    }

    internal void decrementSecondPart()
    {
        secondPart--;
    }
}
