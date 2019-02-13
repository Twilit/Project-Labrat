using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDamage : MonoBehaviour
{
    GameObject blade;
    Transform downPos;
    Transform upPos;
    
    void Start()
    {
        blade = transform.GetChild(0).gameObject;
        downPos = transform.GetChild(1);
        upPos = transform.GetChild(2);

        StartCoroutine("SawMove");
    }

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

                health.Damage(40);
            }
        }
    }

    IEnumerator SawMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            while (Vector3.Distance(blade.transform.position, downPos.position) > 0.05f)
            {

                blade.transform.position = Vector3.MoveTowards(blade.transform.position, downPos.position, 20 * Time.deltaTime);

                yield return null;
            }

            yield return new WaitForSeconds(2f);

            while (Vector3.Distance(blade.transform.position, upPos.position) > 0.05f)
            {

                blade.transform.position = Vector3.MoveTowards(blade.transform.position, upPos.position, 20 * Time.deltaTime);

                yield return null;
            }
        }
    }
}