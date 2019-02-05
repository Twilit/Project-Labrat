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

    public float waitTime;
    public GameObject exit;
    bool spawnedExit;

    void Update()
    {
        if (waitTime <= 0)
        {

        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
