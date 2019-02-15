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
    bool empty = false;

    TileTemplates templates;

    void Start ()
	{
        keyCounter = GameObject.FindGameObjectWithTag("KeyCounter").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();

        audiosource = GetComponent<AudioSource>();
    }
	
	void Update ()
	{
		
	}

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8 && !empty)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8 && !empty)
        {
            transform.GetChild(0).rotation = Quaternion.LookRotation(transform.GetChild(0).position - player.transform.position);
            transform.GetChild(0).eulerAngles = new Vector3(0, transform.GetChild(0).eulerAngles.y, 0);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8 && !empty)
        {
            AudioSource.PlayClipAtPoint(MusicSource, transform.position);

            keys += 1;
            keyCounter.text = "x " + keys;

            empty = true;

            transform.GetChild(1).localPosition = new Vector3(0.85f, 1.6f, -1.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Closed")
        {
            templates.coffins -= 1;
            Destroy(gameObject);
        }
    }
}
