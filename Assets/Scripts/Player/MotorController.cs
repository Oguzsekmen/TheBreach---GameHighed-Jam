using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;
    CharacterController player;
    public float speed;
    public bool gameover = false;
    UIManager uiManager;
    Rigidbody rigidbody;

    private void Start()
    {
        player = GetComponent<CharacterController>();

    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");



    }
    private void FixedUpdate()
    {
        if (!gameover)
        {
            player.Move(new Vector3(horizontalMove * 1f, 0f, 5f) * (20f * Time.deltaTime));

            if (Input.GetAxis("Vertical") > 0)
            {
                player.Move(new Vector3(horizontalMove * 1f, 0f, verticalMove) * (speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0f, 5f, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0f, -5f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            gameover = true;
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        uiManager.GameOver();

    }

}