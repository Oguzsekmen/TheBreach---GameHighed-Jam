using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] Vector3 birdSpeed = new Vector3(0f, 0f, -2f);
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void Start()
    {

        body.velocity = birdSpeed;
    }
}
