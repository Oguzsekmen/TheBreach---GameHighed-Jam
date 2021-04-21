using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRagdoll : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] Vector3 angularSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.angularVelocity = angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
