using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandControlState : BodyBaseControlState, IHandPart
{
    private Transform originPosition;
    private Transform handTarget;
    private float positionX;
    private float positionY;
    private float positionZ;
    private float rotationX;
    private float rotationY;
    private bool isRotate;

    public override void EnterState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.rightHandOrigin;
        handTarget = bodyStateManager.rightHandTarget;
    }

    public override void UptadeState(float mouseX, float mouseY)
    {
        if (!isRotate)
        {
            if (handTarget.position.x == 0)
            {
                Debug.Log("no jest 0");
            }
            positionX += handTarget.position.x * mouseX * Time.deltaTime;
            positionY += handTarget.position.y * mouseY * Time.deltaTime;
            positionX = Mathf.Clamp(positionX, -6.0f, 4.0f);
            positionY = Mathf.Clamp(positionY, -3.0f, 3.0f);

            handTarget.transform.position = new Vector3(positionY, positionZ, -positionX);
        }
        else
        {
            rotationX += mouseX * 6.0f *  Time.deltaTime;
            rotationY += mouseY * 6.0f * Time.deltaTime;
            
            
            handTarget.eulerAngles = new Vector3(rotationX,0,rotationY);
        }
    }

    public void isHandRotate(bool setIsRotate)
    {
        isRotate= setIsRotate;        
    }

    public void changeHandAltitude(float value)
    {
        positionZ += handTarget.position.z * value * Time.deltaTime;

        handTarget.transform.position = new Vector3(-positionY,positionZ,-positionX);
    }

}
