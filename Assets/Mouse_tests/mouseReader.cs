using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;



public class mouseReader : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = NewInput();
    }


    private string legacyMouseInput()
    { 
        Vector3 mousePosition = Input.mousePosition;
        return mousePosition.ToString();
    }

    private string NewInput()
    {
        Vector2 mousePos = Mouse.current.delta.ReadValue();
        return mousePos.ToString(); 
    }

}
