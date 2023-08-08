using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRayDebug : MonoBehaviour
{
    Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        tran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward * 0.7f;
        Debug.DrawRay(tran.position, forward, Color.green);
    }
}
