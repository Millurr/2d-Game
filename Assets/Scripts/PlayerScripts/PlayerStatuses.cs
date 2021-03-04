using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatuses : MonoBehaviour
{

    public HealthBar hb;
    public StaminaBar sb;
    public ManaBar mb;

    public float sprintCoolDown = 2f;
    bool isCoolingDown = false;

    public float maxHealth;
    public float maxStamina;
    public float maxMana;

    public float enduranceMultiplier = 1;
    public float intelegenceMultiplier = 1;

    public float currentHealth;
    public float currentStamina;
    public float currentMana;

    // Start is called before the first frame update
    void Start()
    {
        hb.SetMaxHealth(maxHealth);
        sb.SetMaxStamina(maxStamina);
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    private void FixedUpdate()
    {
        if (!isCoolingDown)
        {
            GainStamina(.1f);
        }
        else
        {
            sprintCoolDown -= Time.fixedDeltaTime;
            if (sprintCoolDown <= 0)
            {
                SetCoolDown(false);
            }
        }
    }

    void SetCoolDown(bool coolDown)
    {
        isCoolingDown = coolDown;
    }

    void GainStamina(float gain)
    {
        if (currentStamina <= 100f)
        {
            currentStamina += gain;
            sb.SetStamina(currentStamina);
        }
    }

    public float LoseStamina(float loss)
    {
        sprintCoolDown = 2f;
        SetCoolDown(true);

        if (currentStamina >= 0f)
        {
            currentStamina -= loss;
            sb.SetStamina(currentStamina);
        }
        return currentStamina;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        hb.SetHealth(currentHealth);
    }

    public void UseMana(float mana)
    {
        currentMana -= mana;
        mb.SetMana(currentMana);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetStamina()
    {
        return currentStamina;
    }

    public float GetMana()
    {
        return currentMana;
    }
}
