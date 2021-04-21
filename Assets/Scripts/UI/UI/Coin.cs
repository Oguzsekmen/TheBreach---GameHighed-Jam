using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int numberOfCoins;
    public Text coinText;
    public Text shopCoinText;
    public int coinPoint;

    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
        //shopCoinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins") + coinPoint;
            PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);
            coinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
            shopCoinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
            Destroy(gameObject);
        }
    }
}
