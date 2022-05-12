
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject teleportationGameObject;
    public bool teleport;

    public InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private void Start()
    {
        teleportActivationReference.action.performed += TeleportToggle;
        teleport = false;
    }

    private void TeleportModeCancel(InputAction.CallbackContext obj) =>  onTeleportCancel.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();

    private void TeleportToggle(InputAction.CallbackContext obj)
    {
        if (teleport)
        {
            TeleportModeCancel(obj);
            teleport = false;
        } else
        {
            TeleportModeActivate(obj);
            teleport = true;
        }
    }
}