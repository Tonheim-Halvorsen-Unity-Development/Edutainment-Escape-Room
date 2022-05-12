using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyPadControll : MonoBehaviour
{
    public int correctCombination;
    public bool accessGranted = false;

    //public GameObject key;

    public UnityEvent onCorrectCode;


    // Start is called before the first frame update
    private void Start()
    {
        //key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(accessGranted == true)
        {
            onCorrectCode.Invoke();
            accessGranted = false;
        }
    }

    public bool CheckIfCorrect(int combination)
    {
        if(combination == correctCombination)
        {
            accessGranted = true;
            return true;
        }
        return false;
    }
}
