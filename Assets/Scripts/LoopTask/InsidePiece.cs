using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class InsidePiece : MonoBehaviour
{
    [SerializeField] private LoopManager linkedLoopManager;

    [SerializeField] private Transform keyPiece;
    [SerializeField] private Transform lightPiece;
    [SerializeField] private Transform nothingPiece;

    private XRSocketInteractor socket;

    private void Awake() => socket = GetComponent<XRSocketInteractor>();

    private void OnEnable()
    {
        if (socket == null)
        {
            socket = GetComponent<XRSocketInteractor>();
        }
        if (socket != null)
        {
            socket.selectEntered.AddListener(ObjectSnapped);
            socket.selectExited.AddListener(ObjectRemoved);
        }
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }

    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectName = arg0.interactableObject;
        if (snappedObjectName.transform.name == keyPiece.name)
        {
            linkedLoopManager.insideKey();
        }
        else if (snappedObjectName.transform.name == lightPiece.name)
        {
            linkedLoopManager.insideLight();
        }
    }
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        linkedLoopManager.insideRemoved();
    }
}

