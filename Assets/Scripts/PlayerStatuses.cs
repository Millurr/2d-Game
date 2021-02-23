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

        public float maxHealth;
        public float maxStamina;

        public float enduranceMultiplier;

        public float currentHealth;
        public float currentStamina;

        // Start is called before the first frame update
        void Start()
        {
            hb.SetMaxHealth(maxHealth);
            sb.SetMaxStamina(maxStamina);
            currentHealth = maxHealth;
            currentStamina = maxStamina;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(20);
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
    }
}
