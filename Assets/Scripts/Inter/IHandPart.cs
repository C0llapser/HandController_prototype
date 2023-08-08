using UnityEngine;

public interface IHandPart  
{
   
    
    void isHandRotate(bool setIsRotate);

    void changeHandAltitude(float value);

    void pickDropObject(BodyStateManager bodyStateManager);

    void pickUpObject();

    void dropObject();

    void offHand(BodyStateManager bodyStateManager);

}
