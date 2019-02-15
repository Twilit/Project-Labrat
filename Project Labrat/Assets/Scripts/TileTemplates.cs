﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileTemplates : MonoBehaviour
{
    public GameObject[] northTiles;
    public GameObject[] eastTiles;
    public GameObject[] southTiles;
    public GameObject[] westTiles;
    public GameObject closedTile;

    public List<GameObject> tiles;

    public GameObject coin;
    public GameObject sawblade;
    public GameObject coffin;
    public GameObject torch;
    public GameObject exit;
    public GameObject loadingPanel;
    public GameObject moreKeysText;
    bool exitSpawned;
    
    public float endtime = 0.5f;
    public int coffins;

    private void Start()
    {
        loadingPanel.SetActive(true);
        coffins = 0;
    }

    void Update()
    {
        if (tiles.Count > 420)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            print("reload; number of tiles: : " + tiles.Count);
        }

        if (endtime > 0)
        {
            endtime -= Time.deltaTime;
        }
        else
        {
            if (!exitSpawned)
            {
                if (tiles.Count > 60 && (tiles[tiles.Count - 1].tag != "Closed"))
                {
                    StartGame();
                    print("start; number of tiles: " + tiles.Count);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    print("reload; number of tiles: : " + tiles.Count);
                }
            }
        }
    }

    public void ResetEndTime()
    {
        endtime = 0.5f;
    }

    void StartGame()
    {
        Instantiate(exit, tiles[tiles.Count - 1].transform.position, Quaternion.identity);
        loadingPanel.SetActive(false);
        exitSpawned = true;
        print(coffins);
    }
}
