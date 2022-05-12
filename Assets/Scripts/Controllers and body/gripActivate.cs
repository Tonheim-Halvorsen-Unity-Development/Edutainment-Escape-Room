using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class gripActivate : MonoBehaviour
{

    public InputActionReference gripReference;

    [Space]
    public UnityEvent onGripActivate;
    public UnityEvent onGripCancel;

    // Start is called before the first frame update
    void Start()
    {
        gripReference.action.performed += gripPerformed;
        gripReference.action.canceled += gripCancel;
    }

    private void gripCancel(InputAction.CallbackContext obj) => onGripCancel.Invoke();

    private void gripPerformed(InputAction.CallbackContext obj) => onGripActivate.Invoke();

}