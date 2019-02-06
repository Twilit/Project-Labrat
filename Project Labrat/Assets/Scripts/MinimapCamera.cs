using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate ()
    {
        transform.position = player.transform.position;
	}
}
