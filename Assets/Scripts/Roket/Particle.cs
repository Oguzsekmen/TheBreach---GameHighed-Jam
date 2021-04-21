using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField]
    ParticleSystem fireFx1=null;
    [SerializeField]
    ParticleSystem fireFx2 = null;
    [SerializeField]
    ParticleSystem fireFx3 = null;

    bool isFly = true;
   
    private void Update()
    {
        
        
        if (Input.GetKey(KeyCode.Space))
        {
            fireFx1.Play();
            fireFx2.Play();
            fireFx3.Play();
        }
    }
}
