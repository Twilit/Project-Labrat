using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuScoreScript : MonoBehaviour {
    private static int score = 0;
    private static int levelsLoaded = 0;
    [SerializeField] Text TotalCoins;
    

    // Use this for initialization
    void Start () {
        score = CoinScript.coins;
        levelsLoaded = Exit.levelsCompleted;

        TotalCoins.text = "Score: " + (int)(score*10 + levelsLoaded*50);

    }
	
	// Update is called once per frame
	void Update () {

    }
    
    
}
