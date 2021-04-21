using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField] Vector3 bombingOffsetMin = new Vector3(-7f, 0f, 20f);
    [SerializeField] Vector3 bombingOffsetMax = new Vector3(5f, 0f, 30f);
    [SerializeField] Vector2 bombMinMaxTimer = new Vector2(3f, 6f);
    float minTimer;
    float maxTimer;
    private bool isBombing=false;
    GameObject car;

    private void Awake()
    {
        minTimer = bombMinMaxTimer.x;
        maxTimer = bombMinMaxTimer.y;
        car = GameObject.FindGameObjectWithTag("Car");
    }

    private void Start()
    {
        // SONRADAN SİLİNİCEK
        IsBombing = true;
    }
    public bool IsBombing
    {
        get
        {
            return isBombing;
        }
        set
        {
            isBombing=value;
            StartCoroutine(Bombing());
        }
    }

    IEnumerator Bombing()
    {
        while (isBombing)
        {
            float randomTimer = UnityEngine.Random.Range(minTimer, maxTimer);
            Vector3 bombPos = new Vector3(Random.Range(bombingOffsetMin.x, bombingOffsetMax.x), bombingOffsetMax.y, Random.Range(bombingOffsetMin.z, bombingOffsetMax.z));
            Instantiate(bomb, car.transform.position + bombPos, Quaternion.identity);
            yield return new WaitForSeconds(randomTimer);
        }
    }
}
