using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockerControl : MonoBehaviour
{
    [SerializeField] float speed;
    
    private void Update()
    {
        var horizonInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizonInput, verticalInput, 0) * Time.deltaTime*speed;
    }
}
