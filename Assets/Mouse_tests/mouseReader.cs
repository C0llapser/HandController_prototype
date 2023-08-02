using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class mouseReader : MonoBehaviour
{
    public Transform cube;

    Vector2 previousMousePosition;
    Vector2 mousePosition;
    Vector2 mouseMovement;
    
    private void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        Debug.Log(mousePosition);
    }
}

