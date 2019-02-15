using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    GameObject player;

    void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	void Update ()
	{
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
