using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
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
            mb.SetMaxMana(maxMana);
            currentHealth = maxHealth;
            currentStamina = maxStamina;
            currentMana = maxMana;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                UseMana(10 * intelegenceMultiplier);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                LoseStamina(1 * enduranceMultiplier);
                sprintCoolDown = 2f;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isCoolingDown = true;
            }

            if (!isCoolingDown && !Input.GetKey(KeyCode.LeftShift))
            {
                GainStamina(.1f);
            }
            else
            {
                sprintCoolDown -= Time.deltaTime;
                if (sprintCoolDown <= 0)
                {
                    isCoolingDown = false;
                }
            }
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
    }
}
