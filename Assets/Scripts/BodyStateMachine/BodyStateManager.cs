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
        switchState(headState);
    }

    //Event when mouse moves
    public void currentStateUptade(float x, float z)
    {
        currentState.UptadeState(x, z);
    }

    
    public void enterRightHandState()
    {
        enterEscapeHandState(rightStateOn, rightHandState);
    }
    public void enterLeftHandState()
    {
        enterEscapeHandState(leftStateOn, leftHandState);
    }


    public void HoldObject()
    {
        if (IHandHolder == null)
            return;

        IHandHolder.pickDropObject(this);
    }

    public void RotateHand()
    {
        rotateHand = rotateHand ? false : true;

        if(IHandHolder != null)
            IHandHolder.isHandRotate(rotateHand);
    }

    public void changeHandAltitude(float y)
    {
        if (IHandHolder != null)
            IHandHolder.changeHandAltitude(y);
    }

    private void enterEscapeHandState(bool handStateBool,BodyBaseControlState whichHandState)
    {
        if (handStateBool)// escape hand state and switch to headState
        {
            switchState(headState);
            IHandHolder.offHand(this);
        }
        else// enter "whichHandState" hand state 
        {
            if (IHandHolder != null)
                IHandHolder.offHand(this);
            
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
