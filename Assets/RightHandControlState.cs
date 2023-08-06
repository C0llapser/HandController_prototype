using UnityEngine;

public class RightHandControlState : BodyBaseControlState, IHandPart
{
    private Transform originPosition;
    private Transform handTarget;
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

    float handSensitivityAxisX;
    float handSensitivityAxisZ;
    float handAltitudeSensitivity;

    public RightHandControlState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.rightHandOrigin;
        handTarget = bodyStateManager.rightHandTarget;
        inputSettings = bodyStateManager.inputSettings;

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
            rotationZ += mouseZ * 0.1f;
            rotationX = Mathf.Clamp(rotationX, clampRotationX.x, clampRotationX.y);
            rotationZ = Mathf.Clamp(rotationZ, clampRotationZ.x, clampRotationZ.y);
            
            handTarget.localEulerAngles = new Vector3(rotationZ,0,rotationX);
        }
    }

    public void isHandRotate(bool setIsRotate)
    {
        isRotate= setIsRotate;        
    }

    public void changeHandAltitude(float value)
    {
        positionY +=value * handAltitudeSensitivity * 0.01f;

        handTarget.transform.localPosition = new Vector3(positionX,positionY,positionZ);
    }

    public void offHand(BodyStateManager bodyStateManager)
    {
        bodyStateManager.rightStateOn = false;
        bodyStateManager.IHandHolder = null;
    }

    public void pickDropObject(BodyStateManager bodyStateManager)
    {

        if (bodyStateManager.rightHandHoldObject)
        {
            pickUpObject(ref bodyStateManager.rightHandHoldObject);
            Debug.Log(bodyStateManager.rightHandHoldObject);
        }
        else
            dropObject(ref bodyStateManager.rightHandHoldObject);

        Debug.Log(bodyStateManager.rightHandHoldObject);
    }

    public void pickUpObject(ref bool isHolding)
    {
        isHolding = true;
    }

    public void dropObject(ref bool isHolding)
    {
        Debug.Log("spuszczam");
        isHolding = false;
    }
}
