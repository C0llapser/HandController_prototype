using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    private PlayerControls controls;
    
    [SerializeField]
    private UnityEvent<float, float> onMouseDeltaEvent;
    [SerializeField]
    private UnityEvent onRightHandOnOFF;
    
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.MouseDelta.performed += MouseDelta;
        controls.Player.RightHandOnOff.performed += ctx =>RightHandOnOff();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.MouseDelta.performed -= MouseDelta;
        controls.Player.RightHandOnOff.performed -= ctx => RightHandOnOff();
    }

    public void RightHandOnOff()
    {
        onRightHandOnOFF?.Invoke();
    }

    public void MouseDelta(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        onMouseDeltaEvent?.Invoke(value.x, value.y);
    }
}
