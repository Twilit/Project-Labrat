using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    Text coinCounter;
    GameObject player;

    public static int coins = 0;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        coinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        transform.GetChild(0).rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }

    private void OnMouseExit()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            print(Vector3.Distance(transform.position, player.transform.position));

            coins += 1;
            coinCounter.text = "x " + coins;

            Destroy(gameObject);
        }
    }
}
