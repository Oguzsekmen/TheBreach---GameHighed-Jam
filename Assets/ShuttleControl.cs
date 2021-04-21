using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShuttleControl : MonoBehaviour
{
    Rigidbody body;
    float xInput;
    float yInput;
    [SerializeField] float horizontalSpeed = 10f;
    [SerializeField] float verticalSpeed = 10f;
    [SerializeField] float horizontalMaxSpeed = 20f;
    [SerializeField] float verticalMaxSpeed = 20f;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        yInput = Mathf.Clamp(yInput, 0f, 1f);
        ShuttleMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mars")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void ShuttleMovement()
    {
        if (body.velocity.y > verticalMaxSpeed || yInput <= 0.05f)
        {
            body.AddForce(0f, -verticalSpeed / 5f, 0f);
        }
        else
        {
            body.AddForce(0f, yInput * verticalSpeed, 0f);
        }
        if (body.velocity.x > horizontalMaxSpeed)
        {
            body.AddForce(-verticalSpeed / 5f, 0f, 0f);
        }
        else if (-body.velocity.x < -horizontalMaxSpeed)
        {
            body.AddForce(verticalSpeed / 5f, 0f, 0f);
        }
        else
        {
            body.AddForce(verticalSpeed * -xInput, 0f, 0f);
        }
    }
}
