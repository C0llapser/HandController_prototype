using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable
{
    private Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    
    public void drop()
    {
        
        gameObject.transform.parent = null;
        rb.isKinematic = false;
        //rb.detectCollisions = true;
    }

    public void pickUp(Transform transform)
    {
        
        gameObject.transform.parent = transform;
        rb.isKinematic = true;
        //rb.detectCollisions = false;
    }
}
