using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class PlayerStatuses : MonoBehaviour
    {

        public HealthBar hb;
        public StaminaBar sb;

        public float sprintCoolDown = 2f;
        bool isCoolingDown = false;

        float maxHealth;
        float maxStamina;

        float enduranceMultiplier;

        public float currentHealth;
        public float currentStamina;

        public StatsObject playerStats;

        // Start is called before the first frame update
        void Start()
        {
            enduranceMultiplier = playerStats.enduranceBuff;

            maxHealth = playerStats.health;
            maxStamina = playerStats.stamina;

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

        public float GetHealth()
        {
            return currentHealth;
        }

        public float GetStamina()
        {
            return currentStamina;
        }
    }
}
