using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandControlState : BodyBaseControlState
{
    Transform originPosition;
    Transform handTarget;
    float positionX;
    float positionY;


    public override void EnterState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.rightHandOrigin;
        handTarget = bodyStateManager.rightHandTarget;
        bodyStateManager.rightStateOn = true;
    }

    public override void UptadeState(float mouseX, float mouseY)
    {
        positionX += handTarget.position.x * mouseX * Time.deltaTime;
        positionY += handTarget.position.y * mouseY * Time.deltaTime;
        positionX = Mathf.Clamp(positionX, -6.0f, 4.0f);
        positionY = Mathf.Clamp(positionY, -3.0f, 3.0f);

        handTarget.transform.localPosition = new Vector3(-positionY, 0, -positionX);

    }
}
