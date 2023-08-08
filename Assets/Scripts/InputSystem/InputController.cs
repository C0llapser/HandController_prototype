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
    [SerializeField]
    private UnityEvent onLeftHandOnOFF;
    [SerializeField]
    private UnityEvent onHold;
    [SerializeField]
    private UnityEvent onRotateHand;
    [SerializeField]
    private UnityEvent<float> onChangingHeightHand;
    
    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.MouseDelta.performed += MouseDelta;
        controls.Player.RightHandOnOff.performed += ctx =>RightHandOnOff();
        controls.Player.LeftHandOnOff.performed += ctx => LeftHandOnOff();
        controls.Player.Hold.started += Hold;
        controls.Player.Hold.canceled += Hold;
        controls.Player.RotateHand.started += ctx => RotateHand();
        controls.Player.RotateHand.canceled += ctx => RotateHand();
        controls.Player.HandAltitude.performed += ChangeHandAltitude;
       
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.MouseDelta.performed -= MouseDelta;
        controls.Player.RightHandOnOff.performed -= ctx => RightHandOnOff();
        controls.Player.LeftHandOnOff.performed -= ctx => LeftHandOnOff();
        controls.Player.Hold.started -= Hold;
        controls.Player.Hold.canceled -= Hold;
        controls.Player.RotateHand.started -= ctx => RotateHand();
        controls.Player.RotateHand.canceled -= ctx => RotateHand();
        controls.Player.HandAltitude.performed -= ChangeHandAltitude;
    }

    public void RightHandOnOff()
    {
        onRightHandOnOFF?.Invoke();
    }
    public void LeftHandOnOff()
    {
        onLeftHandOnOFF?.Invoke();
    }

    public void MouseDelta(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        onMouseDeltaEvent?.Invoke(value.x, value.y);
    }

    public void Hold(InputAction.CallbackContext context)
    {
        onHold?.Invoke();
    }

    public void RotateHand()
    {
        onRotateHand?.Invoke();
    }

    public void ChangeHandAltitude(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        onChangingHeightHand?.Invoke(value);
    }
}
