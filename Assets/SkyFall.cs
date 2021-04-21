using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SkyFall : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float maxVertSpeed = -10f;
    [SerializeField] float gravity = -10f;
    [SerializeField] float xSpeed = 5f;
    [SerializeField] float zSpeed = 5f;
    [SerializeField] float carReachDuration = 2f;
    [SerializeField] GameObject[] materials;
    [SerializeField] Rigidbody ragdollBody;
    GameObject bone;
    float xInput = 0f;
    float yInput = 0f;
    [SerializeField] float horizontalAcceleration = 10f;
    float minAcceptableVelocity = 0.05f;
    PlayerFallingAnimatorController animController;
    Animator animator;
    bool hasLanded = false;
    bool isDead = false;
    AudioSource parasutSFX;
    UIManager uIManager;
   

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        animController = GetComponent<PlayerFallingAnimatorController>();
        animator = GetComponent<Animator>();
        bone = transform.GetChild(0).gameObject;
        SetRagdollStatus(false);
        parasutSFX = GetComponentInChildren<AudioSource>();
        uIManager = FindObjectOfType<UIManager>();
        
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        FallSpeedControl();
        PlayerFallMovement();
        NextLevel();
    }

    private void SetRagdollStatus(bool status)
    {
        BoxCollider collider = transform.GetChild(1).GetComponent<BoxCollider>();
        collider.enabled = !status;
        animator.enabled = !status;
        body.freezeRotation = !status;
        body.useGravity = status;
        bone.SetActive(status);
        foreach (GameObject element in materials)
        {
            element.SetActive(!status);
        }
    }

    private void FallSpeedControl()
    {
        if (body.velocity.y < maxVertSpeed)
        {
            body.AddForce(new Vector3(0f,-gravity/10f,0f), ForceMode.Acceleration);
        }
        if (body.velocity.y > 0.95f * maxVertSpeed)
        {
            body.AddForce(new Vector3(0f,gravity,0f), ForceMode.Acceleration);
        }
    }

    private void PlayerFallMovement()
    {
        if (hasLanded || isDead) { return; }
        if (Mathf.Abs(xInput) >= 0.1f)
        {
            if (Mathf.Abs(body.velocity.x) < Mathf.Abs(xSpeed))
            {
                body.AddForce(new Vector3(xInput * horizontalAcceleration, 0f, 0f), ForceMode.Acceleration);
            }
            else
            {
                if (body.velocity.x >= 0)
                {
                    body.AddForce(new Vector3(-horizontalAcceleration / 10f, 0f, 0f), ForceMode.Acceleration);
                }
                else
                {
                    body.AddForce(new Vector3(horizontalAcceleration / 10f, 0f, 0f), ForceMode.Acceleration);

                }
            }
        }
        else
        {
            if (body.velocity.x > minAcceptableVelocity)
            {
                body.AddForce(new Vector3(-horizontalAcceleration /*/ 10f*/, 0f, 0f), ForceMode.Acceleration);
            }
            else if(body.velocity.x < minAcceptableVelocity)
            {
                body.AddForce(new Vector3(horizontalAcceleration /*/ 10f*/, 0f, 0f), ForceMode.Acceleration);
            }
        }
        if (Mathf.Abs(yInput) >= 0.1f)
        {
            if (Mathf.Abs(body.velocity.z) < Mathf.Abs(zSpeed))
            {
                body.AddForce(new Vector3(0f,0f,yInput* horizontalAcceleration), ForceMode.Acceleration);
            }
            else
            {
                if (body.velocity.z >= 0)
                {
                    body.AddForce(new Vector3(0f,0f,- horizontalAcceleration / 10f), ForceMode.Acceleration);
                }
                else
                {
                    body.AddForce(new Vector3(0f,0f, horizontalAcceleration / 10f), ForceMode.Acceleration);

                }
            }
        }
        else
        {
            if (body.velocity.z > minAcceptableVelocity)
            {
                body.AddForce(new Vector3(0f /*/ 10f*/, 0f, -horizontalAcceleration), ForceMode.Acceleration);
            }
            else
            {
                body.AddForce(new Vector3(0f /*/ 10f*/, 0f, horizontalAcceleration), ForceMode.Acceleration);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OpenParachuteArea" && !isDead)
        {
            maxVertSpeed = maxVertSpeed / 5f;
            animController.OpenParachute();
            StartCoroutine(ParasutSFX());
        }
    }
    IEnumerator ParasutSFX()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        //parasutSFX.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasLanded && collision.gameObject.name == "Ground" && !isDead)
        {
            StartCoroutine(GetInCar());


        }
        else if (collision.gameObject.tag == "Bird")
        {
            Debug.Log("asd");
            isDead = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerFollowCamera>().IsDead = true;
            SetRagdollStatus(true);
            ragdollBody.AddForce(0f, 100f, 0f,ForceMode.VelocityChange);
            ragdollBody.angularVelocity = new Vector3(20f, 30f, 8f);
            StartCoroutine(GameOver());
            
        }
    }

    IEnumerator GetInCar()
    {
        animController.Land();
        StartCoroutine(NexxtLevel());
        GameObject car = GameObject.FindGameObjectWithTag("Car"); 
        body.isKinematic = true;
        transform.DOMove(car.transform.position, carReachDuration);
        transform.DOLookAt(car.transform.position, 1f);
        yield return new WaitForSeconds(carReachDuration-3f);
        gameObject.SetActive(false);        
        
    }
   
    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(3f);
        uIManager.GameOver();
    }
    void NextLevel()
    {
        GameObject car = GameObject.FindGameObjectWithTag("Car");
        float dist = Vector3.Distance(car.transform.position, transform.position);
        if (dist<10f)
        {
            StartCoroutine(NexxtLevel());
        }
        Debug.Log("Distance to other: " + dist);
    }
    IEnumerator NexxtLevel()
    {
        yield return new WaitForSecondsRealtime(10f);
        SceneManager.LoadScene(1);
    }


}

