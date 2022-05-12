using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMovement : MonoBehaviour
{
    public Rigidbody player;

    void stopPlayer()
    {
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }

    private void OnCollisionExit(Collision collision)
    {
        stopPlayer();
    }
}
