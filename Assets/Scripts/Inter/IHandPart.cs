using UnityEngine;

public interface IHandPart  
{
   
    
    void IsHandRotate(bool setIsRotate);

    void ChangeHandAltitude(float value);

    void PickUpObject();

    void DropObject();

    void OffHand(BodyStateManager bodyStateManager);

}
