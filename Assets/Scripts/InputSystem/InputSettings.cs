using UnityEngine;

public class InputSettings : MonoBehaviour
{
    #region camera settings
    public float cameraSensitivity;

    public Vector2 cameraHorizontalClamp;
    public Vector2 cameraVerticalClamp;
    #endregion

    #region hand 
    public float rightHandSensitivityAxisX;
    public float rightHandSensitivityAxisZ;
    
    public Vector2 rightHandAxisClampX;
    public Vector2 rightHandAxisClampZ;
    public Vector2 rightHandRotationClampX;
    public Vector2 rightHandRotationClampZ;

    public float leftHandSensitivityAxisY;
    public float leftHandSensitivityAxisZ;

    public Vector2 leftHandAxisClampX;
    public Vector2 leftHandAxisClampZ;

    public float HandAltitudeSensitivity;
    #endregion
}
