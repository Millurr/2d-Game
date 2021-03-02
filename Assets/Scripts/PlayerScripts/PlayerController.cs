using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
  
    public class PlayerController : MonoBehaviour
    {

        public InventoryObject inventory;
        
        float speed = 5;

        public float walkSpeed = 5f;
        public float sprintSpeed = 7f;

        Character character;
        CharacterController controller;

        public PlayerStatuses playerStatus;
        public PlayerAnimations playerAnimations;
        public PlayerActions playerActions;

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
            if (Input.GetButtonDown("Fire1") && playerStatus.GetStamina() > 0)
            {
                playerAnimations.Attack();
                playerStatus.LoseStamina(20 * playerStatus.enduranceMultiplier);
                playerActions.Attack(10);
            }
        }

        void Sprint()
        {
            if (Input.GetKey(KeyCode.LeftShift) && playerStatus.GetStamina() > 0 && move.sqrMagnitude > 0)
            {
                speed = sprintSpeed;
                playerAnimations.Sprint(controller.velocity.magnitude);
                playerStatus.LoseStamina(1 * playerStatus.enduranceMultiplier);
            }
            else
            {
                playerAnimations.Sprint(controller.velocity.magnitude);
                speed = walkSpeed;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            // inventory.Container.Clear();
        }
    }
}