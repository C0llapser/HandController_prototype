using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandControlState : BodyBaseControlState, IHandPart
{
    private Transform originPosition;
    private Transform handTarget;
    private float positionZ;
    private float positionX;
    private float positionY;
    private float rotationX;
    private float rotationY;
    private bool isRotate;
    
    private InputSettings inputSettings;

    private Vector2 clampAxisX;
    private Vector2 clampAxisZ;

    float handSensitivityAxisX;
    float handSensitivityAxisZ;

    public RightHandControlState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.rightHandOrigin;
        handTarget = bodyStateManager.rightHandTarget;
        inputSettings = bodyStateManager.inputSettings;

        clampAxisX = inputSettings.rightHandAxisClampX;
        clampAxisZ = inputSettings.rightHandAxisClampZ;

        handSensitivityAxisX = inputSettings.rightHandSensitivityAxisX;
        handSensitivityAxisZ = inputSettings.rightHandSensitivityAxisZ;
    }

    public override void EnterState(BodyStateManager bodyStateManager)
    {
        bodyStateManager.rightStateOn = true;
    }

    public override void UptadeState(float mouseX, float mouseZ)
    {
        if (!isRotate)//move hand on X and Z axis
        {
            positionX +=  mouseX * handSensitivityAxisX * 0.01f;
            positionZ +=  mouseZ * handSensitivityAxisZ * 0.01f;
           
            positionX = Mathf.Clamp(positionX, clampAxisZ.x, clampAxisZ.y);
            positionZ = Mathf.Clamp(positionZ, clampAxisZ.x , clampAxisX.y);
             
            handTarget.transform.localPosition = new Vector3(positionX, positionY, positionZ);
        }
        else// rotate hand
        {
            rotationX += mouseX * 0.1f;
            rotationY += mouseZ * 0.1f;
            ////rotationX = Mathf.Clamp(rotationX,-70,70);
            ////rotationY = Mathf.Clamp(rotationY, 10,-180);
            Debug.Log(handTarget.eulerAngles);
            handTarget.localEulerAngles = new Vector3(0,rotationY,rotationX);
        }
    }

    public void isHandRotate(bool setIsRotate)
    {
        isRotate= setIsRotate;        
    }

    public void changeHandAltitude(float value)
    {
        positionY +=value * 0.1f * 0.01f;

        handTarget.transform.localPosition = new Vector3(positionX,positionY,positionZ);
    }

    public void offHand(BodyStateManager bodyStateManager)
    {
        bodyStateManager.rightStateOn = false;
        bodyStateManager.IHandHolder = null;
    }
}
