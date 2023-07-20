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

    public Transform RightHandTarget;
    public Transform RightHandOrigin;
    public Transform LeftHandTarget;
    public Transform LeftHandOrigin;

    private void Awake()
    {
        inputSettings = gameObject.GetComponent<InputSettings>();
    }

    private void Start()
    {
        currentState = headState;
        currentState.EnterState(this);
    }


    public void currentStateUptade(float x, float y)
    {
        currentState.UptadeState(x, y);
    }
    

}
