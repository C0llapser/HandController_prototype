using UnityEngine;

public class BodyStateManager : MonoBehaviour
{

    public BodyBaseControlState currentState;
    public HeadControlState headState = new HeadControlState();
    public RightHandControlState rightHandState;
    public LeftHandControlState leftHandState;
    public IHandPart IHandHolder;


    public Transform cameraTransform;
    public InputSettings inputSettings;

    public Transform rightHandTarget;
    public Transform rightHandOrigin;
    public Transform rightHandpickUpRayOrigin;
    public bool rightStateOn;
    

    public Transform leftHandTarget;
    public Transform leftHandOrigin;
    public Transform leftHandpickUpRayOrigin;
    public bool leftStateOn;



    public bool rotateHand;

    private void Awake()
    {
        inputSettings = gameObject.GetComponent<InputSettings>();
        rightHandState = new RightHandControlState(this);
        leftHandState = new LeftHandControlState(this);
    }

    private void Start()
    {
        rightStateOn = false;
        leftStateOn = false;
        rotateHand = false;
        SwitchState(headState);
    }

    //Event when mouse moves
    public void CurrentStateUptade(float x, float z)
    {
        currentState.UptadeState(x, z);
    }

    
    public void EnterRightHandState()
    {
        EnterEscapeHandState(rightStateOn, rightHandState);
    }
    public void EnterLeftHandState()
    {
        EnterEscapeHandState(leftStateOn, leftHandState);
    }


    public void HoldObject()
    {
        if (IHandHolder == null)
            return;

        IHandHolder.PickDropObject(this);
    }

    public void RotateHand()
    {
        rotateHand = rotateHand ? false : true;

        if(IHandHolder != null)
            IHandHolder.IsHandRotate(rotateHand);
    }

    public void ChangeHandAltitude(float y)
    {
        if (IHandHolder != null)
            IHandHolder.ChangeHandAltitude(y);
    }

    private void EnterEscapeHandState(bool handStateBool,BodyBaseControlState whichHandState)
    {
        if (handStateBool)// escape hand state and switch to headState
        {
            SwitchState(headState);
            IHandHolder.OffHand(this);
        }
        else// enter "whichHandState" hand state 
        {
            if (IHandHolder != null)
                IHandHolder.OffHand(this);
            
            SwitchState(whichHandState);
            IHandHolder = whichHandState as IHandPart;
        }
    }

    private void SwitchState(BodyBaseControlState bodyBaseState)
    {
        currentState = bodyBaseState;
        currentState.EnterState(this);
    }
    

}
