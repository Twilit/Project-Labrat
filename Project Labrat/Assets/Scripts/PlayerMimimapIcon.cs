using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMimimapIcon : MonoBehaviour 
{
    GameObject player;

    void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player");
	}	

	void Update () 
	{
        transform.eulerAngles = new Vector3(180, 0, player.transform.eulerAngles.y);
	}
}
