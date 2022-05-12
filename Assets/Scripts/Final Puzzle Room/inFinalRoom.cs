using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inFinalRoom : MonoBehaviour
{

    [SerializeField] private FinalDoor finalDoor1;
    [SerializeField] private FinalDoor finalDoor2;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider col)
    {
        finalDoor1.inside();
        finalDoor2.inside();
    }
}
