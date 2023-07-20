using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    PlayerControls controls;
    
    [SerializeField]
    UnityEvent<float, float> onMouseDeltaEvent;
    
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.MouseDelta.performed += MouseDelta;
        controls.Player.RightHandOnOff.performed += RightHandOnOff;
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.MouseDelta.performed -= MouseDelta;
        controls.Player.RightHandOnOff.performed -= RightHandOnOff;
    }

    public void RightHandOnOff(InputAction.CallbackContext context)
    {
        Debug.Log("gowno");
    }

    public void MouseDelta(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        onMouseDeltaEvent.Invoke(value.x, value.y);
    }
}
