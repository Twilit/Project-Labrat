﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuScoreScript : MonoBehaviour {
    private static int score;
    private static int levelsLoaded;
    [SerializeField] Text TotalCoins;
    

    // Use this for initialization
    void Start () {
        TotalCoins.text = "Score " + score*10 + levelsLoaded*50;

    }
	
	// Update is called once per frame
	void Update () {
        score = CoinScript.coins;
        levelsLoaded = Exit.levelsCompleted;
    }
    
    
}
