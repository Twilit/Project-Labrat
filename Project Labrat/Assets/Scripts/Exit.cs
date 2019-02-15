using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    
    TileTemplates templates;
    
    void Start ()
    {
        templates = GameObject.FindGameObjectWithTag("Tiles").GetComponent<TileTemplates>();
    }

	void Update ()
    {
     
	}

    private void OnTriggerEnter(Collider other)
    {        
        if (Coffin.keys == templates.coffins)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            StartCoroutine("Prompt");
        }
    }

    IEnumerator Prompt()
    {
        templates.moreKeysText.SetActive(true);
        templates.moreKeysText.GetComponent<Text>().text = "Remaining Keys: " + Coffin.keys;

        yield return new WaitForSeconds(3f);

        templates.moreKeysText.SetActive(false);
    }
}
