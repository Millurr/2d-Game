using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
  
    public class PlayerController : MonoBehaviour
    {
        
        float speed = 5;

        public float walkSpeed = 5f;
        public float sprintSpeed = 7f;

        Character character;
        CharacterController controller;

        public PlayerStatuses currentStatus;
        public PlayerAnimations playerAnimations;
        public PlayerActions playerActions;

        public StatsObject playerStats;

        Vector2 move;

        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            

            if (!playerAnimations.IsAttacking())
            {
                move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
                Attack();
            }
            else
            {
                move = new Vector2(0, 0);
            }

            playerAnimations.Direction(move);

            Sprint();
        }

        void FixedUpdate()
        {
            MoveCharacter();
        }

        void MoveCharacter()
        {
            controller.Move(move * speed * Time.fixedDeltaTime);
        }

        void Attack()
        {
            if (Input.GetButtonDown("Fire1") && currentStatus.GetStamina() > 0)
            {
                playerAnimations.Attack();
                currentStatus.LoseStamina(20 * playerStats.enduranceBuff);
                playerActions.Attack(10);
            }
        }

        void Sprint()
        {
            if (Input.GetKey(KeyCode.LeftShift) && currentStatus.GetStamina() > 0 && move.sqrMagnitude > 0)
            {
                speed = sprintSpeed;
                playerAnimations.Sprint(controller.velocity.magnitude);
                currentStatus.LoseStamina(1 * playerStats.enduranceBuff);
            }
            else
            {
                playerAnimations.Sprint(controller.velocity.magnitude);
                speed = walkSpeed;
            }
        }
    }
}