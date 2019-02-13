using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    Text coinCounter;
    public static int coins = 0;

    void Start()
    {
        coinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<Text>();
    }

    private void OnMouseDown()
    {
        coins += 1;
        coinCounter.text = "x " + coins;

        Destroy(gameObject);
    }
}
