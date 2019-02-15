using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] int maximumHealth = 100;
    int currentHealth = 100;

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    void Start()
    {
        // this means that crrentHealth will be = to the maxhealth that i have set.
        currentHealth = maximumHealth;
    }

    private void Update()
    {
        content.fillAmount = (float)currentHealth / maximumHealth;

        if (Input.GetKeyDown(KeyCode.U))
        {
            Damage(10);
        }

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
        print(currentHealth / maximumHealth);
        // this meas if the currenthealth = 0 then the player object will be destory form the game.
        if (currentHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);

        }




    }
}
         

