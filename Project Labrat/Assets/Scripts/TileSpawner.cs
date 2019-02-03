using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public enum OpeningDirection { North, East, South, West, };
    public OpeningDirection needOpening;
    public bool spawned = false;

    GameObject map;
    TileTemplates templates;
    int rand;

    void Start ()
    {
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();
        map = GameObject.FindGameObjectWithTag("Map");
        Invoke("Spawn", 0.1f);
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
                    GameObject northTile = Instantiate(templates.northTiles[rand], transform.position, templates.northTiles[rand].transform.rotation);

                    northTile.transform.parent = map.transform;
                    northTile.transform.localScale = Vector3.one;

                    break;

                case OpeningDirection.East:
                    // Spawns tile with an eastern opening
                    rand = Random.Range(0, templates.eastTiles.Length);
                    GameObject eastTile = Instantiate(templates.eastTiles[rand], transform.position, templates.eastTiles[rand].transform.rotation);

                    eastTile.transform.parent = map.transform;
                    eastTile.transform.localScale = Vector3.one;
                    break;

                case OpeningDirection.South:
                    // Spawns tile with an southern opening
                    rand = Random.Range(0, templates.southTiles.Length);
                    GameObject southTile = Instantiate(templates.southTiles[rand], transform.position, templates.southTiles[rand].transform.rotation);

                    southTile.transform.parent = map.transform;
                    southTile.transform.localScale = Vector3.one;
                    break;

                case OpeningDirection.West:
                    // Spawns tile with an western opening
                    rand = Random.Range(0, templates.westTiles.Length);
                    GameObject westTile = Instantiate(templates.westTiles[rand], transform.position, templates.westTiles[rand].transform.rotation);

                    westTile.transform.parent = map.transform;
                    westTile.transform.localScale = Vector3.one;
                    break;
            }

            spawned = true;
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
