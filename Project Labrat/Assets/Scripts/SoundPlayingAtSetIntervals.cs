using UnityEngine;
using System.Collections;

public class SoundPlayingAtSetIntervals : MonoBehaviour
{
    public float time = 30f; //30 seconds for you
    AudioSource audiosource;

    public AudioClip MusicSource;

    public void Update()

    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Play Audio Here -- Timer Over!!");
            audiosource.PlayOneShot(MusicSource);
        }


    }
}