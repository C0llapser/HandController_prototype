using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControlState : BodyBaseControlState
{
    Transform cameraTransfrom;
    
    private float camHorizontal;
    private float camVertical;

    private Vector2 camHorizontalClamp;
    private Vector2 camVerticalClamp;


    InputSettings inputSettings;
    
    public override void EnterState(BodyStateManager bodyStateManager) 
    {
        this.cameraTransfrom = bodyStateManager.cameraTransform;
        inputSettings = bodyStateManager.inputSettings;
        camHorizontalClamp = inputSettings.cameraHorizontalClamp;
        camVerticalClamp = inputSettings.cameraVerticalClamp;
        
    }

    public override void UptadeState(float mouseX, float mouseY)
    {
        camVertical += Mathf.Clamp(mouseX * inputSettings.cameraSensitivity * Time.deltaTime,camHorizontalClamp.x, camHorizontalClamp.y);
        camHorizontal += Mathf.Clamp(mouseY * inputSettings.cameraSensitivity * Time.deltaTime,camVerticalClamp.x,camVerticalClamp.y);
        
        cameraTransfrom.localEulerAngles = new Vector3(-camHorizontal,camVertical,0.0f);
    }

}
