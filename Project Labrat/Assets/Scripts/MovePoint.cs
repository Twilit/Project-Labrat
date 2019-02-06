﻿using System.Collections;
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
        GameObject selectedMovePoint = selectedTile.transform.GetChild(0).gameObject;

        if (!connectedTiles.Contains(selectedMovePoint))
        {
            connectedTiles.Add(selectedMovePoint);

            selectedMovePoint.GetComponent<MovePoint>().AddConnection(transform.parent.gameObject);
        }
    }

    public bool CheckConnection(GameObject selectedMovePoint/*, Player.Direction facing, string dir*/)
    {
        List<GameObject> otherConnectedTiles = selectedMovePoint.GetComponent<MovePoint>().connectedTiles;

        if (connectedTiles.Contains(selectedMovePoint) && otherConnectedTiles.Contains(gameObject))
        {
            return true;
        }
        else
        {
            return false;
        }

        /*switch (facing)
        {
            case Player.Direction.North:

                if (dir == "forward")
                {
                    if (connectedTiles.Contains())
                }
                else if (dir == "backward")
                {

                }
                else if (dir == "left")
                {

                }
                else if (dir == "right")
                {

                }

                break;

            case Player.Direction.East:

                if (dir == "forward")
                {

                }
                else if (dir == "backward")
                {

                }
                else if (dir == "left")
                {

                }
                else if (dir == "right")
                {

                }

                break;

            case Player.Direction.South:

                if (dir == "forward")
                {

                }
                else if (dir == "backward")
                {

                }
                else if (dir == "left")
                {

                }
                else if (dir == "right")
                {

                }

                break;

            case Player.Direction.West:

                if (dir == "forward")
                {

                }
                else if (dir == "backward")
                {

                }
                else if (dir == "left")
                {

                }
                else if (dir == "right")
                {

                }

                break;
        }*/
    }

    public void MoveOccupant(GameObject target)
    {
        try
        {
            target.GetComponent<MovePoint>().occupant = occupant;

            occupant = null;
        }
        catch
        {
            print("Can't move there!");
        }       
    }
}
