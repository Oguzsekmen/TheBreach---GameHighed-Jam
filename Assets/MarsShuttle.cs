using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsShuttle : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndGame());
        body = GetComponent<Rigidbody>();
        body.velocity = new Vector3(0f, 0f, speed);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }

}
