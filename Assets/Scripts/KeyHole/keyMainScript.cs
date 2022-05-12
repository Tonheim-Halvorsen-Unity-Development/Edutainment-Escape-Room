using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMainScript : MonoBehaviour
{
    public int numKeys = 0;
    public int numKeysWin = 3;

    [SerializeField] private FinalDoor finalDoor1;
    [SerializeField] private FinalDoor finalDoor2;


    public void IncrementKeys()
    {
        numKeys++;
        if (numKeys >= 3)
        {
            finalDoor1.openFinalDoor();
            finalDoor2.openFinalDoor();
        }
    }

    public void DecrementKeys()
    {
        numKeys--;
    }




}
