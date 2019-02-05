using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public List<GameObject> connectedTiles;
    public GameObject occupant;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

    public void AddConnection(GameObject selectedTile)
    {
        try
        {
            GameObject selectedMovePoint = selectedTile.transform.GetChild(0).gameObject;

            if (!connectedTiles.Contains(selectedMovePoint))
            {
                connectedTiles.Add(selectedMovePoint);

                selectedMovePoint.GetComponent<MovePoint>().AddConnection(transform.parent.gameObject);
            }
        }
        catch
        {
            print("Can't move there!");
        }
    }

    public void MoveOccupant(GameObject target)
    {
        target.GetComponent<MovePoint>().occupant = occupant;

        occupant = null;        
    }
}
