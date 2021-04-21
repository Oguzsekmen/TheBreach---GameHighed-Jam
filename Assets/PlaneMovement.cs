using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] Vector3 speed = new Vector3(0f, 0f, 10f);
    bool isDispatched = false;
    GameObject player;
    AudioSource flySFX;
    
    
   
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        flySFX = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Start()
    {
        body.velocity = speed;
        flySFX.Play();
        
    }
    private void Update()
    {
        
        if (!isDispatched && transform.position.z >= 0f)
        {
            FindObjectOfType<PlayerFollowCamera>().CurrentPlayerState = PlayerState.Falling;
            player.SetActive(true);
            //player.transform.position = transform.position;
            Destroy(gameObject, 10f);
            
        }
    }
}
