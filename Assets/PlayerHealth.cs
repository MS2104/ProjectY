using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("UI")]
    public Image healthBar;
    public Image shieldBar;
    public Text healthText;
    public Text shieldText;

    [Header("Health stats")]
    [SerializeField] int maxHealth = 100, maxShield = 100;
    [SerializeField] int health, shield;

    private bool hasShield;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        shield = maxShield;

        if (shield > 0)
        {
            hasShield = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Clamp health and shield to prevent overflow
        health = Mathf.Clamp(health, 0, maxHealth);
        shield = Mathf.Clamp(shield, 0, maxShield);

        // Update UI elements
        healthBar.fillAmount = (float)health / maxHealth;
        shieldBar.fillAmount = (float)shield / maxShield;

        healthText.text = health.ToString();
        shieldText.text = shield.ToString();

        // Handle shield depletion and transfer damage to health
        if (shield <= 0 && hasShield)
        {
            hasShield = false;
        }

        // Handle key input for testing
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            int damage = Random.Range(10, 20);

            if (hasShield)
            {
                if (shield >= damage)
                {
                    // Shield absorbs all the damage
                    shield -= damage;
                }
                else
                {
                    // Shield can't fully absorb the damage
                    int remainingDamage = damage - shield;
                    shield = 0;
                    hasShield = false; // Shield is depleted
                    health -= remainingDamage; // Transfer remaining damage to health
                }
            }
            else
            {
                // Direct damage to health when no shield
                health -= damage;
            }
        }
    }
}
