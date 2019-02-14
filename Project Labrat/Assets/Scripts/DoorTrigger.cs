using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    [SerializeField] GameObject Door;
    bool isOpened = false;

    private void OnTriggerEnter(Collider col)
    {
        if (isOpened == false)
        {
            isOpened = true;
            Door.transform.position += new Vector3(0, 4, 0);
            StartCoroutine("doorStoop");
        }


    }

    IEnumerator doorStoop()
    {
        yield return new WaitForSeconds(Random.Range(3,6));
        if (isOpened == true)
        {
            isOpened = false;
            Door.transform.position += new Vector3(0, -4, 0);
        }

    }
}