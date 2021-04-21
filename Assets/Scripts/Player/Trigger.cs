using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    UIManager uiManager;
    private void Start()
    {
        uiManager = GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Debug.Log("GameOver");
            //uiManager.GameOver();
        }
    }
}
