using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Health Variables
    int maxHealth, currentHealth;

    [SerializeField] Image healthUI;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.transform.localScale = new Vector3(currentHealth / (float)maxHealth, 1, 1);

        if (currentHealth <= 0) 
        { 
            gameObject.SetActive(false);
        }
    }
}
