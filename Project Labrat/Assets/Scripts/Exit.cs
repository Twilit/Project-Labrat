using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public static int levelsCompleted;

    void Start ()
    {
		
	}

	void Update ()
    {
     
	}

    private void OnTriggerEnter(Collider other)
    {
        
        levelsCompleted += 1;
    
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
