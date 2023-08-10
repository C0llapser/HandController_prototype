using UnityEngine;

public class RightHandControlState : BodyBaseControlState, IHandPart
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
    private bool isHandHoldingObject;


    public RightHandControlState(BodyStateManager bodyStateManager)
    {
        originPosition = bodyStateManager.rightHandOrigin;
        handTarget = bodyStateManager.rightHandTarget;
        inputSettings = bodyStateManager.inputSettings;
        
        pickUpRayOrigin = bodyStateManager.rightHandpickUpRayOrigin;

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

    public void IsHandRotate(bool setIsRotate)
    {
        isRotate= setIsRotate;        
    }

    public void ChangeHandAltitude(float value)
    {
        positionY +=value * handAltitudeSensitivity * 0.01f;

        handTarget.transform.localPosition = new Vector3(positionX,positionY,positionZ);
    }

    public void OffHand(BodyStateManager bodyStateManager)
    {
        bodyStateManager.rightStateOn = false;
        bodyStateManager.IHandHolder = null;
    }

    public void PickDropObject(BodyStateManager bodyStateManager)
    {
        if (isHandHoldingObject)//if hand doesnt hold anything
        {
            DropObject();
        }
        else//if hand hold something
            PickUpObject();   
    }

    public void PickUpObject()
    {
        Ray pickUpRay = new Ray(pickUpRayOrigin.position, pickUpRayOrigin.forward);

        if (Physics.Raycast(pickUpRay, out RaycastHit hitInfo, 0.7f))
        {
            
            if ((pickUp = hitInfo.collider.gameObject.GetComponent<IPickable>())!=null)
            {
                pickUp.PickUp(pickUpRayOrigin);
                isHandHoldingObject= true;
            }
        }
        
    }

    public void DropObject()
    {
        pickUp.Drop();
        pickUp = null;
        isHandHoldingObject = false;
    }
}
