using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrWheel : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;

    private float minLenght;
    private float maxLenght;
    private float springLength;
    private float springForce;
    private float springVelocoty;
    private float lastLength;
    private float damperForce;
    
    
    public float wheelRadius;
    

    private Vector3 suspensionForce;

    
    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody>();

        minLenght = restLength - springTravel;
        maxLenght = restLength + springTravel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLenght + wheelRadius))
        {
            lastLength = springLength;

            springLength = hit.distance - wheelRadius;
            springLength = Mathf.Clamp(springLength,minLenght,maxLenght);
            springVelocoty = (lastLength - springLength)/Time.fixedDeltaTime;
            springForce = springStiffness * (restLength - springLength);

            
            damperForce = damperStiffness * springVelocoty;
            
            suspensionForce = (springForce * damperStiffness) * transform.up;

            rb.AddForceAtPosition(suspensionForce,hit.point);
        }
    }
}
