using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    bool moving;
    float moveSpeed = 3f;
    float turnSpeed = 15f;

    GameObject pointSensor;
    
    GameObject targetedPoint;
    GameObject currentPoint;

	void Start ()
	{
        pointSensor = transform.GetChild(0).gameObject;
	}
	
	void Update ()
	{
        targetedPoint = pointSensor.GetComponent<PointSensor>().targetedPoint;

        Move();
        Turn();
	}

    public void Move()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && !moving)
        {
            pointSensor.transform.localPosition = new Vector3(0, 0, 5f);

            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && !moving)
        {
            pointSensor.transform.localPosition = new Vector3(0, 0, -5f);

            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && !moving)
        {
            pointSensor.transform.localPosition = new Vector3(25f, 0, 0);

            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && !moving)
        {
            pointSensor.transform.localPosition = new Vector3(-25f, 0, 0);

            StartCoroutine("PositionChange", targetedPoint.transform);
        }
    }

    public void Turn()
    {
        if (Input.GetButton("TurnLeft") && !moving)
        {
            StartCoroutine("RotationChange", -90f);
        }

        if (Input.GetButton("TurnRight") && !moving)
        {
            StartCoroutine("RotationChange", 90f);
        }
    }

    IEnumerator PositionChange(Transform target)
    {
        moving = true;

        currentPoint.GetComponent<MovePoint>().MoveOccupant(targetedPoint);

        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            yield return null;
        }              

        yield return new WaitForSeconds(0.1f);

        moving = false;
    }

    IEnumerator RotationChange(float angle)
    {
        moving = true;

        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0, angle, 0) * startRot;

        while (Quaternion.Angle(transform.rotation, endRot) > 0.05f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, endRot, turnSpeed * Time.deltaTime);

            yield return null;
        }        

        yield return new WaitForSeconds(0.1f);

        moving = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (!moving)
        {
            currentPoint = other.gameObject;
        }        
    }
}
