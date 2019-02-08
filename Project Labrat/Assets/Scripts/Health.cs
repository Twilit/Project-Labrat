using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 100;


    void Start()
    {
        // this means that crrentHealth will be = to the maxhealth that i have set.
        currentHealth = maximumHealth;


    }
    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }
    public void Damage(int damageValue)
    {
        //Debug.Log("Damage");
        currentHealth -= damageValue;
        // this meas if the currenthealth = 0 then the player object will be destory form the game.


    }


}
         

