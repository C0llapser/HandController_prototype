using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BodyStateManager : MonoBehaviour
{

    public BodyBaseControlState currentState;
    public HeadControlState headState = new HeadControlState();
    public RightHandControlState rightHandState = new RightHandControlState();
    public LeftHandControlState leftHandState = new LeftHandControlState();
    public IHandPart IHandHolder;

    public float mouseY;
    public float mouseX;

    public Transform cameraTransform;
    public InputSettings inputSettings;

    public Transform rightHandTarget;
    public Transform rightHandOrigin;
    public bool rightStateOn;
    public bool rightHandHoldObject;

    public Transform leftHandTarget;
    public Transform leftHandOrigin;
    public bool leftStateOn;
    public bool leftHandHoldObject;

    public bool isHolding;

    public bool rotateHand;

    private void Awake()
    {
        inputSettings = gameObject.GetComponent<InputSettings>();
    }

    private void Start()
    {
        rightStateOn = false;
        leftStateOn = false;
        rotateHand = false;
        switchState(headState);
    }

    public void currentStateUptade(float x, float y)
    {
        currentState.UptadeState(x, y);
    }

    public void enterRightHandState()
    {
        enterHandState(rightStateOn, rightHandState);
    }
    public void enterLeftHandState()
    {
        enterHandState(leftStateOn, leftHandState);
    }

    public void HoldObject()
    {
        if (!rightStateOn && !leftStateOn)
            return;

        Debug.Log("trzymaj");
    }

    public void RotateHand()
    {
        if (!rightStateOn && !leftStateOn)
            return;
        
        rotateHand = rotateHand ? false : true;

        if(IHandHolder != null)
            IHandHolder.isHandRotate(rotateHand);
    }

    public void changeHandAltitude(float x)
    {
        if (IHandHolder != null)
            IHandHolder.changeHandAltitude(x);
    }

    private void enterHandState(bool handStateBool,BodyBaseControlState whichHandState)
    {
        if (handStateBool)// exit left hand state and switch to headState
        {
            handStateBool = false;
            switchState(headState);
            IHandHolder = null;
        }
        else// enter "whichHandState" hand state 
        {
            handStateBool = true;
            switchState(whichHandState);
            IHandHolder = whichHandState as IHandPart;
        }
    }

    private void switchState(BodyBaseControlState bodyBaseState)
    {
        currentState = bodyBaseState;
        currentState.EnterState(this);
    }
    

}
