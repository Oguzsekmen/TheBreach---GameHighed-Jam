using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigge : MonoBehaviour
{
    AudioSource audio;
    UIManager uIManager;
    void Aweke()
    {
        audio = GetComponent<AudioSource>();
        uIManager = FindObjectOfType<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.NextLevel();
            SceneManager.LoadScene(1);
        }
    }
}
