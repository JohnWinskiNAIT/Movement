using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Health Variables
    [SerializeField] int maxHealth, currentHealth;

    [SerializeField] Image healthUI;
    [SerializeField] TMP_Text healthValue;
    [SerializeField] GameObject destructible;
    [SerializeField] GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
        healthValue.text = currentHealth.ToString();
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.transform.localScale = new Vector3(currentHealth / (float)maxHealth, 1, 1);
        healthValue.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        gameObject.SetActive(false);
        if (destructible != null)
        {
            Instantiate(destructible, transform.position, transform.rotation);
        }
        if (explosionParticle != null)
        {
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
    }
}