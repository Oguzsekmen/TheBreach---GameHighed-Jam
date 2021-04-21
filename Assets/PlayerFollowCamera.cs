using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { None , Falling , Driving , RocketFlying}
public class PlayerFollowCamera : MonoBehaviour
{
    private PlayerState currentPlayerState;
    [SerializeField] GameObject ragdoll;
    Vector3 playerPos;
    GameObject player;
    GameObject airplane;
    [SerializeField] Vector2 zBoundaries = new Vector2(1.5f, 9f);
    [SerializeField] Vector3 fallScreenBoundaries = new Vector3(5.5f, 7f, 1f);
    bool isDead = false;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
            player = ragdoll;
        }
    }
    //[SerializeField] Vector3 fallCameraLookAt = new Vector3(0f, 0f, 0f);
    public PlayerState CurrentPlayerState
    {
        get
        {
            return currentPlayerState;
        }
        set
        {
            currentPlayerState = value;
            if (currentPlayerState == PlayerState.Falling)
            {
                transform.eulerAngles = new Vector3(60f, 0f, 0f);
            }
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        airplane = GameObject.Find("Airplane");
    }

    void Start()
    {
        currentPlayerState = PlayerState.None;
    }

    void LateUpdate()
    {
        playerPos = player.transform.position;
        ManageFollowCamera();
    }

    private void ManageFollowCamera()
    {
        if (currentPlayerState == PlayerState.None)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, airplane.transform.position.z);
        }
        else if (currentPlayerState == PlayerState.Falling)
        {
            float xTarget = transform.position.x;
            float yTarget = playerPos.y + fallScreenBoundaries.y;
            float zTarget = transform.position.z;
            if (playerPos.x-transform.position.x > fallScreenBoundaries.x)
            {
                xTarget = playerPos.x - fallScreenBoundaries.x;
            }
            else if (playerPos.x - transform.position.x < -fallScreenBoundaries.x)
            {
                xTarget = playerPos.x + fallScreenBoundaries.x;
            }
            if (playerPos.z - transform.position.z > zBoundaries.y)
            {
                zTarget = playerPos.z - zBoundaries.y;
            }
            else if (transform.position.z - playerPos.z > zBoundaries.x)
            {
                zTarget = playerPos.z + zBoundaries.x;
            }
            transform.position = new Vector3(xTarget,yTarget,zTarget);
        }
    }
}
