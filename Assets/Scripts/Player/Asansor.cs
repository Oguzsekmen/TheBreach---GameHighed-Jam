using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Asansor : MonoBehaviour
{
    [SerializeField]
    Animator asansor;
    [SerializeField] GameObject player;
    [SerializeField] GameObject car;

    private void Start()
    {
        player.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Car"))
        {
            StartCoroutine(ReachRocket());
        }
    }

    IEnumerator ReachRocket()
    {
        FindObjectOfType<MotorController>().gameover = true;
        FindObjectOfType<CameraFollow>().isFollow = false;
        Camera.main.transform.position = GameObject.FindGameObjectWithTag("LastCamPos").transform.position;
        Camera.main.transform.rotation = GameObject.FindGameObjectWithTag("LastCamPos").transform.rotation;
        player.SetActive(true);
        player.transform.position = car.transform.position + new Vector3(0f, 0f, 0f);
        car.GetComponent<Rigidbody>().isKinematic = true;
        car.GetComponentInChildren<Rigidbody>().isKinematic = true;
        car.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        car.GetComponentInChildren<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        player.transform.DOMove(GameObject.Find("1st Point").transform.position,6f);
        player.transform.LookAt(GameObject.Find("1st Point").transform.position);
        yield return new WaitForSeconds(6f);
        player.SetActive(false);
        asansor.SetTrigger("asansor");
        yield return new WaitForSeconds(1.67f);
        player.SetActive(true);
        player.transform.position = GameObject.Find("2nd Point").transform.position;
        player.transform.LookAt(GameObject.Find("3rd Point").transform.position);
        player.transform.DOMove(GameObject.Find("3rd Point").transform.position, 1f);
        yield return new WaitForSeconds(1f);
        player.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
