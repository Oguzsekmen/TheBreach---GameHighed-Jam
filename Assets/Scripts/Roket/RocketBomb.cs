using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBomb : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject bomb;
    [SerializeField] Vector3 bombingOffsetMin = new Vector3(-7f, 0f, 20f);
    [SerializeField] Vector3 bombingOffsetMax = new Vector3(5f, 0f, 30f);
    Rigidbody rigidbody;
    bool isBombing = false;
    float minTimer;
    float maxTimer;
    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        isBombing = true;
    }
    private void Update()
    {
        
    }
    public bool IsBombing
    {
        get
        {
            return isBombing;
        }
        set
        {
            isBombing = value;
            StartCoroutine(Bombing());
        }
    }

    IEnumerator Bombing()
    {
        while (isBombing)
        {
            float randomTimer = UnityEngine.Random.Range(minTimer, maxTimer);
           // rigidbody.velocity = new Vector3(Random.Range(bombingOffsetMin.x, bombingOffsetMax.x), (bombingOffsetMax.y), 0f);
            Vector3 bombPos = new Vector3(Random.Range(bombingOffsetMin.x, bombingOffsetMax.x), (bombingOffsetMax.y), 0f);
            Instantiate(bomb,new Vector3(0,0,0),Quaternion.identity);
            yield return new WaitForSeconds(randomTimer);
        }
    }
}
