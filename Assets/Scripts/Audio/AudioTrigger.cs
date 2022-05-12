using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public keyMainScript keysPlaced;
    public int oneTimeEvent = 1;

    private void Update()
    {
        if (keysPlaced.numKeys == 3)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (oneTimeEvent == 1)
        {
            audioSource.Play();
            oneTimeEvent += 1;
        }
    }
}
