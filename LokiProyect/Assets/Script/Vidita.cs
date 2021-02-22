using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidita : MonoBehaviour
{
        public int restoreHealth = 0;
    	public int maxHealth = 100;
	public int currentHealth;
	
	public healthBar healthbar;
    void Start()
    {
        	currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
	/*if (currentHealth <= 10)
	{
	   healthbar.SetHealth(currentHealth+=90);
	}*/
    }


    // Update is called once per frame
    public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthbar.SetHealth(currentHealth);
		healthbar.SetHealth(currentHealth+=restoreHealth);
	}
}
