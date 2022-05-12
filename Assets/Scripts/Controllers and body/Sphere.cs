using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public bool teleport;
    public GameObject sphere;

    private void Start()
    {
        teleport = false;
    }
    public void disableSphere()
    {
        if (!teleport)
        {
            sphere.SetActive(false);
        }
    }

    public void enableSphere()
    {
        if (!teleport)
        {
            Invoke("enablSphereDelayed", 0.1f);
        }
    }

    void enablSphereDelayed()
    {
        sphere.SetActive(true);
    }

    public void swapTeleportMode()
    {
        if (teleport)
        {
            teleport = false;
        } else
        {
            teleport = true;
        }
    }
}

