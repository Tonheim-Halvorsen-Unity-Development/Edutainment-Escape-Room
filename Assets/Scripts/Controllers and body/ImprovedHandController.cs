using UnityEngine;
using UnityEngine.InputSystem;

public class ImprovedHandController : MonoBehaviour
{
    [SerializeField] InputActionReference controllerActionTrigger;

    private Animator _handAnimator;

    public ImprovedHandController Instance { get; private set; }

    private void Awake()
    {
        _handAnimator = GetComponent<Animator>();
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        float triggerValue = obj.ReadValue<float>();
        if(_handAnimator != null)
        {
            _handAnimator.SetFloat("Trigger", triggerValue);
        }
    } 

    private void UpdateHandAnimation()
    {
        //av og på trigger
        controllerActionTrigger.action.performed += TriggerPress;
    }

    private void Update()
    {
        if(_handAnimator != null)
        {
            UpdateHandAnimation();
        }
    }


}