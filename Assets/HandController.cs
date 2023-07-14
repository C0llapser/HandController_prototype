using UnityEngine;

public class HandController : MonoBehaviour
{
    private bool rightHandMode;
    private float handTransformX;
    private float handTransformY;
    [SerializeField]
    private float mouseSensitivityX;
    [SerializeField]
    private float mouseSensitivityY;

    float positionX = 0;
    float positionY = 0;

    [SerializeField]
    private Transform handTransformObject;

    public void assignValueToVariable()
    {
        this.rightHandMode = false;
        
        handTransformObject =
            handTransformObject == null ?
            null : handTransformObject;
    
    }

    void Start()
    {
        assignValueToVariable();
    }

    
    void Update()
    {
        switchRightHandControllMode();
        rightHandControll();
    }

    //Controll my right hand 
    private void rightHandControll()
    {
        if (!rightHandMode)
            return;

        handTransformX = Input.GetAxis("Mouse X");
        handTransformY = Input.GetAxis("Mouse Y");
        Debug.Log(handTransformX);
        positionX += transform.position.x * handTransformX * Time.deltaTime;
        positionY += transform.position.y * handTransformY * Time.deltaTime;
        positionX = Mathf.Clamp(positionX , -6.0f, 4.0f);
        positionY = Mathf.Clamp(positionY, -3.0f, 3.0f);
       // handTransformObject.transform.position += new Vector3(Mathf.Clamp(handTransformY, -3.0f, 3.0f), 0, -Mathf.Clamp(handTransformX, -3.0f, 3.0f));
        
        handTransformObject.transform.localPosition = new Vector3(-positionY,0,-positionX);

    }
    
    // OFF/ON my right hand 
    private void switchRightHandControllMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rightHandMode = !rightHandMode;
            //send information mesage
            string message =  rightHandMode ? "enter right hand controll mode" : "escape right hand controll mode";
            Debug.Log(message);
        }    
    }


}
