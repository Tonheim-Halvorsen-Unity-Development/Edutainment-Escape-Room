using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    public Transform MainCamera;
    public Transform feet;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = new Vector3 (MainCamera.position.x, feet.position.y, MainCamera.position.z);
    }
}
