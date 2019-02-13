using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

	void Start ()
    {
		
	}

	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
