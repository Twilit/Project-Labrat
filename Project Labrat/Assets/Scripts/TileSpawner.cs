using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public enum OpeningDirection { North, East, South, West, };
    public OpeningDirection needOpening;
    public bool spawned = false;

    TileTemplates templates;
    int rand;

    void Start ()
    {
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();
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
                    Instantiate(templates.northTiles[rand], transform.position, templates.northTiles[rand].transform.rotation);
                    break;

                case OpeningDirection.East:
                    // Spawns tile with an eastern opening
                    rand = Random.Range(0, templates.eastTiles.Length);
                    Instantiate(templates.eastTiles[rand], transform.position, templates.eastTiles[rand].transform.rotation);
                    break;

                case OpeningDirection.South:
                    // Spawns tile with an southern opening
                    rand = Random.Range(0, templates.southTiles.Length);
                    Instantiate(templates.southTiles[rand], transform.position, templates.southTiles[rand].transform.rotation);
                    break;

                case OpeningDirection.West:
                    // Spawns tile with an western opening
                    rand = Random.Range(0, templates.westTiles.Length);
                    Instantiate(templates.westTiles[rand], transform.position, templates.westTiles[rand].transform.rotation);
                    break;
            }

            spawned = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<TileSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
