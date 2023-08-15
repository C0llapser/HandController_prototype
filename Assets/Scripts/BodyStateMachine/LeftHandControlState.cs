using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandControlState : BodyBaseControlState, IHandPart
{
    private Transform originPosition;
    private Transform handTarget;
    private Transform pickUpRayOrigin;
    private float positionZ;
    private float positionX;
    private float positionY;
    private float rotationX;
    private float rotationZ;
    private bool isRotate;

    private InputSettings inputSettings;

    private Vector2 clampAxisX;
    private Vector2 clampAxisZ;
    private Vector2 clampRotationX;
    private Vector2 clampRotationZ;

    private float handSensitivityAxisX;
    private float handSensitivityAxisZ;
    private float handAltitudeSensitivity;

    private IPickable pickUp;

    public LeftHandControlState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.leftHandOrigin;
        handTarget = bodyStateManager.leftHandTarget;
        inputSettings = bodyStateManager.inputSettings;

        pickUpRayOrigin = bodyStateManager.leftHandpickUpRayOrigin;

        //loading settings(from script not file ?file maybe latter?)
        clampAxisX = inputSettings.rightHandAxisClampX;
        clampAxisZ = inputSettings.rightHandAxisClampZ;
        clampRotationX = inputSettings.rightHandRotationClampX;
        clampRotationZ = inputSettings.rightHandRotationClampZ;
        handSensitivityAxisX = inputSettings.rightHandSensitivityAxisX;
        handSensitivityAxisZ = inputSettings.rightHandSensitivityAxisZ;
        handAltitudeSensitivity = inputSettings.HandAltitudeSensitivity;
    }

    public override void EnterState(BodyStateManager bodyStateManager)
    {
        bodyStateManager.leftStateOn = true;
    }

    public override void UptadeState(float mouseX, float mouseZ)
    {
        if (!isRotate)//move hand on X and Z axis
        {
            positionX += mouseX * handSensitivityAxisX * 0.01f;
            positionZ += mouseZ * handSensitivityAxisZ * 0.01f;

            positionX = Mathf.Clamp(positionX, clampAxisZ.x, clampAxisZ.y);
            positionZ = Mathf.Clamp(positionZ, clampAxisZ.x, clampAxisX.y);

            handTarget.transform.localPosition = new Vector3(positionX, positionY, positionZ);
        }
        else// rotate hand
        {
            rotationX += mouseX * 0.1f;
            rotationZ += mouseZ * 0.1f;
            rotationX = Mathf.Clamp(rotationX, clampRotationX.x, clampRotationX.y);
            rotationZ = Mathf.Clamp(rotationZ, clampRotationZ.x, clampRotationZ.y);

            handTarget.localEulerAngles = new Vector3(rotationZ, 0, rotationX);
        }
    }

    public void IsHandRotate(bool setIsRotate)
    {
        isRotate = setIsRotate;
    }

    public void ChangeHandAltitude(float value)
    {
        positionY += value * handAltitudeSensitivity * 0.01f;

        handTarget.transform.localPosition = new Vector3(positionX, positionY, positionZ);
    }

    public void OffHand(BodyStateManager bodyStateManager)
    {
        bodyStateManager.leftStateOn = false;
        bodyStateManager.IHandHolder = null;
    }

    public void PickUpObject()
    {
        Ray pickUpRay = new Ray(pickUpRayOrigin.position, pickUpRayOrigin.forward);

        if (Physics.Raycast(pickUpRay, out RaycastHit hitInfo, 0.7f))
        {

            if ((pickUp = hitInfo.collider.gameObject.GetComponent<IPickable>()) != null)
            {
                pickUp.PickUp(pickUpRayOrigin);
            }
        }
    }

    public void DropObject()
    {
        if (pickUp != null)
        {
            pickUp.Drop();
            pickUp = null;
        }
    }
}
