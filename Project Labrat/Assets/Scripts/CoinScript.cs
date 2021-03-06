﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    Text coinCounter;
    GameObject player;
   
    AudioSource audiosource;

    public AudioClip MusicSource;


    public static int coins = 0;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);

        coinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");

        audiosource = GetComponent<AudioSource>();

    }

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        transform.GetChild(0).rotation = Quaternion.LookRotation(transform.GetChild(0).position - player.transform.position);
        transform.GetChild(0).eulerAngles = new Vector3(0, transform.GetChild(0).eulerAngles.y, 0);
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8)
        {

            AudioSource.PlayClipAtPoint(MusicSource, transform.position);

            coins += 1;
            coinCounter.text = "x " + coins;

            Destroy(gameObject);
        }
    }
}
