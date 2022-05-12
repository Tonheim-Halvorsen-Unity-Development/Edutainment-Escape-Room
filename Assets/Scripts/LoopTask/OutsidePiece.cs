using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class OutsidePiece : MonoBehaviour
{
    [SerializeField] private LoopManager linkedLoopManager;

    [SerializeField] private Transform whilePiece;
    [SerializeField] private Transform ifTruePiece;
    [SerializeField] private Transform ifFalsePiece;

    private XRSocketInteractor socket;

    private void Awake() => socket = GetComponent<XRSocketInteractor>();

    private void OnEnable()
    {
        if (socket == null)
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
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }

    private void ObjectSnapped(SelectEnterEventArgs arg0)
    {
        var snappedObjectName = arg0.interactableObject;
        if (snappedObjectName.transform.name == whilePiece.name)
        {
            linkedLoopManager.outsideWhile();
        } else if (snappedObjectName.transform.name == ifTruePiece.name)
        {
            linkedLoopManager.outsideIf();
        }
    }
    private void ObjectRemoved(SelectExitEventArgs arg0)
    {
        linkedLoopManager.outsideRemoved();
    }
}
