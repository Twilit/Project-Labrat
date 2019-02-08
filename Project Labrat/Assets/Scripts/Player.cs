using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    bool moving;
    float moveSpeed = 10f;
    float turnSpeed = 15f;

    public enum Direction { North, East, South, West};
    Direction facing;

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
        facing = Direction.North;
	}
	
	void Update ()
	{      
        Move();
        Turn();
	}

    public void Move()
    {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            GoForward();
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            GoBackward();
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            GoLeft();
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GoRight();
        }
    }

    public void GoForward()
    {
        if (!moving)
        {
            targetedPoint = pointSensorFront.GetComponent<PointSensor>().targetedPoint;

            if ((targetedPoint != null) && currentPoint.GetComponent<MovePoint>().CheckConnection(targetedPoint))
            {
                StartCoroutine("PositionChange", targetedPoint.transform);
            }

            targetedPoint = null;
        }
    }

    public void GoBackward()
    {
        if (!moving)
        {
            targetedPoint = pointSensorBack.GetComponent<PointSensor>().targetedPoint;

            if ((targetedPoint != null) && currentPoint.GetComponent<MovePoint>().CheckConnection(targetedPoint))
            {
                StartCoroutine("PositionChange", targetedPoint.transform);
            }

            targetedPoint = null;
        }
    }

    public void GoLeft()
    {
        if (!moving)
        {
            targetedPoint = pointSensorLeft.GetComponent<PointSensor>().targetedPoint;

            if ((targetedPoint != null) && currentPoint.GetComponent<MovePoint>().CheckConnection(targetedPoint))
            {
                StartCoroutine("PositionChange", targetedPoint.transform);
            }

            targetedPoint = null;
        }
    }

    public void GoRight()
    {
        if (!moving)
        {
            targetedPoint = pointSensorRight.GetComponent<PointSensor>().targetedPoint;

            if ((targetedPoint != null) && currentPoint.GetComponent<MovePoint>().CheckConnection(targetedPoint))
            {
                StartCoroutine("PositionChange", targetedPoint.transform);
            }

            targetedPoint = null;
        }
    }

    public void Turn()
    {     
        if (Input.GetButton("TurnLeft"))
        {
            TurnLeft();
        }

        if (Input.GetButton("TurnRight"))
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        if (!moving)
        {
            StartCoroutine("RotationChange", -90f);
        }        
    }

    public void TurnRight()
    {
        if (!moving)
        {
            StartCoroutine("RotationChange", 90f);
        }        
    }

    Direction UpdateDirection(Direction faceDir, float angle)
    {
        string turnDir = "";

        if (angle == -90)
        {
            turnDir = "left";
        }
        else if (angle == 90)
        {
            turnDir = "right";
        }

        if (turnDir == "left")
        {
            if (faceDir == Direction.North)
            {
                faceDir = Direction.West;
            }
            else if (faceDir == Direction.East)
            {
                faceDir = Direction.North;
            }
            else if (faceDir == Direction.South)
            {
                faceDir = Direction.East;
            }
            else if (faceDir == Direction.West)
            {
                faceDir = Direction.South;
            }
        }
        else if (turnDir == "right")
        {
            if (faceDir == Direction.North)
            {
                faceDir = Direction.East;
            }
            else if (faceDir == Direction.East)
            {
                faceDir = Direction.South;
            }
            else if (faceDir == Direction.South)
            {
                faceDir = Direction.West;
            }
            else if (faceDir == Direction.West)
            {
                faceDir = Direction.North;
            }
        }

        return faceDir;
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

        facing = UpdateDirection(facing, angle);
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
