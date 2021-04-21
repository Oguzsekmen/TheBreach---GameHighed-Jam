using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] Vector3 initialSpeed = new Vector3(0f, -3f, 0f);
    [SerializeField] float bombSpeed;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = initialSpeed;
    }

    private void Update()
    {
        body.AddForce(new Vector3(0f, -bombSpeed, 0f), ForceMode.Acceleration);
    }
}
