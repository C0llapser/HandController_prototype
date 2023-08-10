using UnityEngine;

public interface IPickable 
{
    void PickUp(Transform transform);

    void Drop();
}
