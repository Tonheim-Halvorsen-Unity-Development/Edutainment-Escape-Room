using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class IfPuzzle : MonoBehaviour
{
    [SerializeField] private Transform correctPiece;
    [SerializeField] private ifManager linkedIfManager;

    private XRSocketInteractor socket;

    private void Awake() => socket = GetComponent<XRSocketInteractor>();

    private void OnEnable()
    {
        if(socket == null)
        {
            socket = GetComponent<XRSocketInteractor>();
        }
        if(socket != null)
        {
            socket.selectEntered.AddListener(ObjectSnapped);
            socket.selectExited.AddListener(ObjectRemoved);
        }
    }

    private void OnDisable()
    {
        if (socket == null)
        {
            socket = GetComponent<XRSocketInteractor>();
        }
        if (socket != null)
        {
            socket.selectEntered.RemoveListener(ObjectSnapped);
            socket.selectExited.RemoveListener(ObjectRemoved);
        }
    }

    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectName = arg0.interactableObject;
        if (snappedObjectName.transform.name == correctPiece.name)
        {
            linkedIfManager.correctPiece();
        }
    }
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        linkedIfManager.removedPiece();
    }
}
