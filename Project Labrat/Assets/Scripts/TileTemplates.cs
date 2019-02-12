using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool exitSpawned;
    
    public static float endtime = 3;

    void Update()
    {
        if (endtime > 0)
        {
            endtime -= Time.deltaTime;
        }
        else
        {
            if (!exitSpawned)
            {
                Instantiate(exit, tiles[tiles.Count-1].transform.position, Quaternion.identity); 

                exitSpawned = true;
            }
        }
    }

    public void ResetEndTime()
    {
        endtime = 3;
    }
}
