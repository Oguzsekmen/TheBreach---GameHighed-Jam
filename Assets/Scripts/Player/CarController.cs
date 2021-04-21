using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    CharacterController player;

    bool isBreaking;
    float currentBreakForce;
    float currentSteerAngle;
    [SerializeField] float speed;
    [SerializeField] float motorForce;
    [SerializeField] float breakForce;
    [SerializeField] float maxSteeringAngle;
    [SerializeField] private WheelCollider arkaSolTekerCollider;
    [SerializeField] private WheelCollider arkaSagTekerCollider;
    [SerializeField] private WheelCollider onSolTekerCollider;
    [SerializeField] private WheelCollider onSagTekerCollider;

    [SerializeField] private Transform arkaSolTekerTransform;
    [SerializeField] private Transform arkaSagTekerTransform;
    [SerializeField] private Transform onSolTekerTransform;
    [SerializeField] private Transform onSagTekerTransform;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();

        //player.Move(new Vector3(horizontalInput * 1, 0, 1f) * (speed * Time.deltaTime));

        //if (Input.GetKey(KeyCode.W))
        //{
        //    player.Move(new Vector3(horizontalInput, 0, verticalInput + 1) * (speed * Time.deltaTime));
        //}

    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(onSolTekerCollider, onSolTekerTransform);
        UpdateSingleWheel(onSagTekerCollider, onSagTekerTransform);
        UpdateSingleWheel(arkaSagTekerCollider, arkaSagTekerTransform);
        UpdateSingleWheel(arkaSolTekerCollider, arkaSolTekerTransform);
    }

    private void UpdateSingleWheel(WheelCollider tekerCollider, Transform tekerTransform)
    {
        Vector3 pos;
        Quaternion rot;
        tekerCollider.GetWorldPose(out pos, out rot);
        tekerTransform.rotation = rot;
        tekerTransform.position = pos;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        onSolTekerCollider.steerAngle = currentSteerAngle;
        onSagTekerCollider.steerAngle = currentSteerAngle;  
    }

    private void HandleMotor()
    {    
            onSagTekerCollider.motorTorque = verticalInput * motorForce;
            onSolTekerCollider.motorTorque = verticalInput * motorForce;
            currentBreakForce = isBreaking ? breakForce : 0f;        
            ApplyBreaking();        

    }

    private void ApplyBreaking()
    {
        onSagTekerCollider.brakeTorque = currentBreakForce;
        onSolTekerCollider.brakeTorque = currentBreakForce;
        arkaSagTekerCollider.brakeTorque = currentBreakForce;
        arkaSolTekerCollider.brakeTorque = currentBreakForce;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }
}
