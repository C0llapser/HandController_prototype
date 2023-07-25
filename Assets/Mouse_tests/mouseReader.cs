using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class mouseReader : MonoBehaviour
{
    public Transform cube;

    float x;
    float y;
    private void Update()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();
        x +=  mouse.x * Time.deltaTime;
        y +=  mouse.y * Time.deltaTime;

        cube.eulerAngles = new Vector3(x, y, 0);
    }
}

