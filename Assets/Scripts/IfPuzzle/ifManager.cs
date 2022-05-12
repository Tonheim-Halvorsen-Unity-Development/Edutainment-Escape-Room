using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ifManager : MonoBehaviour
{
    public GameObject key;

    private void Start()
    {
        key.SetActive(false);
    }

    internal void correctPiece()
    {
        key.SetActive(true);
    }

    internal void removedPiece()
    {
        key.SetActive(false);
    }
}
