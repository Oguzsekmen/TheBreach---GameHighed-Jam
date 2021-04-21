using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;

    private void Start()
    {
       
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            //transform.position = GameObject.FindGameObjectWithTag("Car").transform.position; 
            particle.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("çarpışma" + other.tag);
        if (other.CompareTag("Car"))
        {
            Debug.Log("içerde");
            //transform.position = GameObject.FindGameObjectWithTag("Car").transform.position; 
            other.GetComponentInParent<Takla>().TaklaAt();
            particle.Play();
        }
        particle.Play();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 1f);

    }
}
