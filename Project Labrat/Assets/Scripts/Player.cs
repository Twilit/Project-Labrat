using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IMoveable
{
    public enum ButtonDir { Forward, Backward, Left, Right, TurnLeft, TurnRight, None};
    ButtonDir buttonHeld;
    GameObject uiButtons;
    ColorBlock buttonColours;

    Image forwardButton;
    Image backwardButton;
    Image leftButton;
    Image rightButton;
    Image turnLeftButton;
    Image turnRighttButton;

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
    AudioSource audiosource;

    public AudioClip MusicSource;

    TileTemplates templates;

	void Start ()
    
	{
        facing = Direction.North;
        buttonHeld = ButtonDir.None;

        uiButtons = GameObject.FindGameObjectWithTag("Buttons");
        buttonColours = uiButtons.transform.GetChild(0).GetComponent<Button>().colors;

        audiosource = GetComponent<AudioSource>();
        
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();

    }

   
    void Update ()
	{
        if (templates.endtime <= 0)
        {
            Move();
            Turn();
        }
	}

    public void Move()
    {
        if (Input.GetAxisRaw("Vertical") == 1 || buttonHeld == ButtonDir.Forward)
        {
            GoForward();

        }
        else if (Input.GetAxisRaw("Vertical") == -1 || buttonHeld == ButtonDir.Backward)
        {
            GoBackward();

        }
        else if (Input.GetAxisRaw("Horizontal") == -1 || buttonHeld == ButtonDir.Left)
        {
            GoLeft();

        }
        else if (Input.GetAxisRaw("Horizontal") == 1 || buttonHeld == ButtonDir.Right)
        {
            GoRight();

        }

        if (!moving)
        {
            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void ButtonDown(string _buttonHeld)
    {
        if (_buttonHeld == "Forward")
        {
            buttonHeld = ButtonDir.Forward;
            
        }
        else if (_buttonHeld == "Backward")
        {
            buttonHeld = ButtonDir.Backward;
        }
        else if (_buttonHeld == "Left")
        {
            buttonHeld = ButtonDir.Left;
        }
        else if (_buttonHeld == "Right")
        {
            buttonHeld = ButtonDir.Right;
        }
        else if (_buttonHeld == "TurnLeft")
        {
            buttonHeld = ButtonDir.TurnLeft;
        }
        else if (_buttonHeld == "TurnRight")
        {
            buttonHeld = ButtonDir.TurnRight;
        }
    }

    public void ButtonUp()
    {
        buttonHeld = ButtonDir.None;
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

            int butNum = 0;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }                
            }
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

            int butNum = 1;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
            }
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

            int butNum = 2;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
            }
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

            int butNum = 3;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    public void Turn()
    {     
        if (Input.GetButton("TurnLeft") || buttonHeld == ButtonDir.TurnLeft)
        {
            TurnLeft();
        }
        else if (Input.GetButton("TurnRight") || buttonHeld == ButtonDir.TurnRight)
        {
            TurnRight();
        }
    }

    public void TurnLeft()
    {
        if (!moving)
        {
            StartCoroutine("RotationChange", -90f);

            int butNum = 4;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }        
    }

    public void TurnRight()
    {
        if (!moving)
        {
            StartCoroutine("RotationChange", 90f);

            int butNum = 5;
            uiButtons.transform.GetChild(butNum).GetComponent<Button>().interactable = false;

            for (int i = 0; i < uiButtons.transform.childCount; i++)
            {
                if (i != butNum)
                {
                    uiButtons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
            }
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

        if (!audiosource.isPlaying)
            audiosource.PlayOneShot(MusicSource);

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

        if (!audiosource.isPlaying)
            audiosource.PlayOneShot(MusicSource);
        yield return new WaitForSeconds(0.1f);

        while (Quaternion.Angle(transform.rotation, endRot) > 0.05f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, endRot, turnSpeed * Time.deltaTime);

            yield return null;
        }

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
