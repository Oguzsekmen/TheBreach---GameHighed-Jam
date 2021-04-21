using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    [SerializeField]
    float deneme;
    public bool isFollow = true;

    private void Update()
    {
        if (isFollow)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 6, player.transform.position.z - deneme);
            gameObject.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
        }
    }
}
