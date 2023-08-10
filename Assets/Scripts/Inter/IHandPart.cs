using UnityEngine;

public interface IHandPart  
{
   
    
    void IsHandRotate(bool setIsRotate);

    void ChangeHandAltitude(float value);

    void PickDropObject(BodyStateManager bodyStateManager);

    void PickUpObject();

    void DropObject();

    void OffHand(BodyStateManager bodyStateManager);

}
