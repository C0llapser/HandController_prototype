using UnityEngine;

public interface IPickable 
{
    void pickUp(Transform transform);

    void drop();
}
