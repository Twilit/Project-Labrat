using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public enum OpeningDirection { North, East, South, West, };
    public OpeningDirection needOpening;
    public bool spawned = false;

    TileTemplates templates;
    GameObject map;
    GameObject movePoint;

    int rand;

    void Start ()
    {
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();
        map = GameObject.FindGameObjectWithTag("Map");
        movePoint = transform.parent.GetChild(0).gameObject;

        Invoke("Spawn", 0.05f);
	}
	
	void Spawn()
    {
        if (spawned == false)
        {
            switch (needOpening)
            {
                case OpeningDirection.North:
                    // Spawns tile with an northern opening
                    rand = Random.Range(0, templates.northTiles.Length);
                    GameObject northTile = Instantiate(templates.northTiles[rand], transform.position + new Vector3 (0, 0.001f, 0), templates.northTiles[rand].transform.rotation);
                    templates.ResetEndTime();
                    SpawnItem(northTile);

                    northTile.transform.parent = map.transform;
                    northTile.transform.localScale = Vector3.one;

                    movePoint.GetComponent<MovePoint>().AddConnection(northTile);

                    break;

                case OpeningDirection.East:
                    // Spawns tile with an eastern opening
                    rand = Random.Range(0, templates.eastTiles.Length);
                    GameObject eastTile = Instantiate(templates.eastTiles[rand], transform.position + new Vector3(0, -0.001f, 0), templates.eastTiles[rand].transform.rotation);
                    templates.ResetEndTime();
                    SpawnItem(eastTile);

                    eastTile.transform.parent = map.transform;
                    eastTile.transform.localScale = Vector3.one;

                    movePoint.GetComponent<MovePoint>().AddConnection(eastTile);
                    break;

                case OpeningDirection.South:
                    // Spawns tile with an southern opening
                    rand = Random.Range(0, templates.southTiles.Length);
                    GameObject southTile = Instantiate(templates.southTiles[rand], transform.position + new Vector3(0, 0.002f, 0), templates.southTiles[rand].transform.rotation);
                    templates.ResetEndTime();
                    SpawnItem(southTile);

                    southTile.transform.parent = map.transform;
                    southTile.transform.localScale = Vector3.one;

                    movePoint.GetComponent<MovePoint>().AddConnection(southTile);
                    break;

                case OpeningDirection.West:
                    // Spawns tile with an western opening
                    rand = Random.Range(0, templates.westTiles.Length);
                    GameObject westTile = Instantiate(templates.westTiles[rand], transform.position + new Vector3(0, -0.002f, 0), templates.westTiles[rand].transform.rotation);
                    templates.ResetEndTime();
                    SpawnItem(westTile);

                    westTile.transform.parent = map.transform;
                    westTile.transform.localScale = Vector3.one;

                    movePoint.GetComponent<MovePoint>().AddConnection(westTile);
                    break;
            }
            spawned = true;
        }
	}

    void SpawnItem(GameObject tile)
    {
        int i = Random.Range(0, 6);

        if (i == 0)
        {
            GameObject coin = Instantiate(templates.coin, transform.position + new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-1f, 1f)), Quaternion.identity);
        }

        i = Random.Range(0, 12);

        if (i == 0)
        {
            GameObject sawblade = Instantiate(templates.sawblade, transform.position, Quaternion.identity);
        }

        int t = Random.Range(0, 8);

        if (tile.tag == "TB")
        {         
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, -90, 0));
                torch.transform.GetChild(0).localPosition = new Vector3(0, 3, -3.5f);
            }
        }
        else if (tile.tag == "LR")
        {
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, 180, 0));
                torch.transform.GetChild(0).localPosition = new Vector3(0, 3, -3.5f);
            }
        }
        else if (tile.tag == "T")
        {
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, 0, 0));
            }            
        }
        else if (tile.tag == "B")
        {
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, 180, 0));
            }            
        }
        else if (tile.tag == "L")
        {
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, -90, 0));
            }            
        }
        else if (tile.tag == "R")
        {
            if (t == 0)
            {
                GameObject torch = Instantiate(templates.torch, transform.position, Quaternion.Euler(0, 90, 0));
            }            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<TileSpawner>().spawned == false && spawned == false)
            {
                // spawn walls blocking openings
                GameObject closedTile = Instantiate(templates.closedTile, transform.position, Quaternion.identity);

                closedTile.transform.parent = map.transform;
                closedTile.transform.localScale = Vector3.one;

                Destroy(gameObject);
            }

            spawned = true;
        }
    }
}
