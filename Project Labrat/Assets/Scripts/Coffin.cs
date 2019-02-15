using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coffin : MonoBehaviour
{
    Text keyCounter;
    GameObject player;

    AudioSource audiosource;

    public AudioClip MusicSource;

    public static int keys = 0;

    void Start ()
	{
        keyCounter = GameObject.FindGameObjectWithTag("KeyCounter").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");

        audiosource = GetComponent<AudioSource>();
    }
	
	void Update ()
	{
		
	}

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        transform.GetChild(0).rotation = Quaternion.LookRotation(transform.GetChild(0).position - player.transform.position);
        transform.GetChild(0).eulerAngles = new Vector3(0, transform.GetChild(0).eulerAngles.y, 0);
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8)
        {
            AudioSource.PlayClipAtPoint(MusicSource, transform.position);

            keys += 1;
            keyCounter.text = "x " + keys;

            transform.GetChild(1).localPosition = new Vector3(0.85f, 1.6f, -1.5f);
        }
    }
}
