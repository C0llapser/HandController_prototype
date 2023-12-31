using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation_test : MonoBehaviour
{
    float speedH = 2.0f;
    float speedV = 2.0f;

    float yaw = 0.0f;
    float pitch = 0.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
