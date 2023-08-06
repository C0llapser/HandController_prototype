using UnityEngine;

public interface IHandPart  
{
   
    
    void isHandRotate(bool setIsRotate);

    void changeHandAltitude(float value);

    void pickDropObject(BodyStateManager bodyStateManager);

    void pickUpObject(ref bool isHolding);

    void dropObject(ref bool isHolding);

    void offHand(BodyStateManager bodyStateManager);

}
