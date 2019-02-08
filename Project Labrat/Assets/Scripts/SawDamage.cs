using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == "Player")
        {

            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {

                health.Damage(100);
            }
        }
    }
}