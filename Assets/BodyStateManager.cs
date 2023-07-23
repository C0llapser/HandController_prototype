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

    private void Awake()
    {
        inputSettings = gameObject.GetComponent<InputSettings>();
    }

    private void Start()
    {
        rightStateOn = false;
        leftStateOn = false;
        switchState(headState);
    }

    public void currentStateUptade(float x, float y)
    {
        currentState.UptadeState(x, y);
    }

    public void enterRightHandState()
    {
        if (rightStateOn)
        {
            rightStateOn = false;
            switchState(headState);
            
        }
        else
        {
            rightStateOn = true;
            switchState(rightHandState);
        }
    }
    public void enterLeftHandState()
    {
        if (leftStateOn)
        {
            leftStateOn = false;
            switchState(headState);
        }
        else
        {
            leftStateOn = true;
            switchState(leftHandState);
        }
    }

    public void HoldObject()
    {
        if (!rightStateOn || !leftStateOn)
            return;

        Debug.Log("trzymam :" + rightHandHoldObject); 

    }

    private void switchState(BodyBaseControlState bodyBaseState)
    {
        currentState = bodyBaseState;
        currentState.EnterState(this);
    }
}
