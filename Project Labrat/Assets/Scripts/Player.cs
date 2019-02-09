using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    bool moving;
    public enum Buttons { Forward, Backward, Left, Right, TurnLeft, TurnRight, None};
    Buttons buttonHeld;

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
        buttonHeld = Buttons.None;
	}
	
	void Update ()
	{      
        Move();
        Turn();
	}

    public void Move()
    {
        if (Input.GetAxisRaw("Vertical") == 1 || buttonHeld == Buttons.Forward)
        {
            GoForward();
        }
        else if (Input.GetAxisRaw("Vertical") == -1 || buttonHeld == Buttons.Backward)
        {
            GoBackward();
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 || buttonHeld == Buttons.Left)
        {
            GoLeft();
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 || buttonHeld == Buttons.Right)
        {
            GoRight();
        }
    }

    public void ButtonDown(string _buttonHeld)
    {
        if (_buttonHeld == "Forward")
        {
            buttonHeld = Buttons.Forward;
        }
        else if (_buttonHeld == "Backward")
        {
            buttonHeld = Buttons.Backward;
        }
        else if (_buttonHeld == "Left")
        {
            buttonHeld = Buttons.Left;
        }
        else if (_buttonHeld == "Right")
        {
            buttonHeld = Buttons.Right;
        }
        else if (_buttonHeld == "TurnLeft")
        {
            buttonHeld = Buttons.TurnLeft;
        }
        else if (_buttonHeld == "TurnRight")
        {
            buttonHeld = Buttons.TurnRight;
        }
    }

    public void ButtonUp()
    {
        buttonHeld = Buttons.None;
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
        if (Input.GetButton("TurnLeft") || buttonHeld == Buttons.TurnLeft)
        {
            TurnLeft();
        }
        else if (Input.GetButton("TurnRight") || buttonHeld == Buttons.TurnRight)
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
