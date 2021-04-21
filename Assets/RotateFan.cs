using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFan : MonoBehaviour
{
    [SerializeField] float fanSpeed = 300f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, fanSpeed * Time.deltaTime, 0f);
    }
}
