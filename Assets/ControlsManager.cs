using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControlsManager : MonoBehaviour
{
    private Vector2 mouseDelta;

    UnityEvent<float,float> onMouseDeltaEvent;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        ReadMouseDelta();
    }

    private void ReadMouseDelta()
    {
        mouseDelta = Mouse.current.delta.ReadValue();
    }

    public Vector2 GetMouseDelta()
    {
        return mouseDelta; 
    }

}
