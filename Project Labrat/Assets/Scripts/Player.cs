using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    bool moving;
    float moveSpeed = 10f;
    float turnSpeed = 15f;

    [SerializeField]
    GameObject pointSensorFront;
    [SerializeField]
    GameObject pointSensorBack;
    [SerializeField]
    GameObject pointSensorLeft;
    [SerializeField]
    GameObject pointSensorRight;

    GameObject targetedPoint;
    [SerializeField]
    GameObject currentPoint;

	void Start ()
	{
        
	}
	
	void Update ()
	{      
        Move();
        Turn();
	}

    public void Move()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && !moving)
        {
            targetedPoint = pointSensorFront.GetComponent<PointSensor>().targetedPoint;
            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Vertical") == -1 && !moving)
        {
            targetedPoint = pointSensorBack.GetComponent<PointSensor>().targetedPoint;
            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && !moving)
        {
            targetedPoint = pointSensorLeft.GetComponent<PointSensor>().targetedPoint;
            StartCoroutine("PositionChange", targetedPoint.transform);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && !moving)
        {
            targetedPoint = pointSensorRight.GetComponent<PointSensor>().targetedPoint;
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
        currentPoint = targetedPoint;

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
            //currentPoint = other.gameObject;
        } 
    }
}
