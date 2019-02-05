using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSensor : MonoBehaviour
{
    public GameObject targetedPoint;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
	}

    void OnTriggerStay(Collider other)
    {
        targetedPoint = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        targetedPoint = null;
    }
}
