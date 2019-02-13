using System.Collections;
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
    public GameObject exit;
    public GameObject loadingPanel;
    bool exitSpawned;
    
    public static float endtime = 3;

    void Update()
    {
        if (tiles.Count > 300)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (endtime > 0)
        {
            endtime -= Time.deltaTime;
        }
        else
        {
            if (!exitSpawned)
            {
                if (tiles.Count > 200)
                {
                    StartGame();
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }

    public void ResetEndTime()
    {
        endtime = 3;
    }

    void StartGame()
    {
        Instantiate(exit, tiles[tiles.Count - 1].transform.position, Quaternion.identity);
        loadingPanel.SetActive(false);
        exitSpawned = true;
    }
}
