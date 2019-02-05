using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTiles : MonoBehaviour
{
    TileTemplates templates;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();
        templates.tiles.Add(this.gameObject);
    }
}
