﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{

    public enum IdleDirections
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
  
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        int health = 100;

        [SerializeField]
        int stamina = 100;

        [SerializeField]
        int speed = 5;

        public SpriteRenderer sr;

        public Animator animator;

        Character character;
        CharacterController controller;

        public Transform LookAtObj;

        IdleDirections idleDir = IdleDirections.DOWN;

        Vector2 move;

        // Start is called before the first frame update
        void Start()
        {
            character = new Character(health, stamina, speed);
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        void FixedUpdate()
        {
            MoveCharacter();
        }

        void MoveCharacter()
        {
            controller.Move(move * character.Speed * Time.fixedDeltaTime);
            LookAtDirection();
            SetIdleDirections();
        }

        // Rotate the character depending on if it's moving left or right
        void LookAtDirection()
        {
            animator.SetFloat("Vertical", move.y);
            animator.SetFloat("Speed", move.sqrMagnitude);

            if (move.x > -1f && sr.flipX == true)
            {
                sr.flipX = false;
            }

            if (move.y > 0)
            {
                idleDir = IdleDirections.UP;
            }

            if (move.y < 0)
            {
                idleDir = IdleDirections.DOWN;
            }

            if (move.x < 0)
            {
                sr.flipX = true;
                idleDir = IdleDirections.LEFT;
                animator.SetFloat("Horizontal", move.x);
            }
            
            if (move.x > 0)
            {
                idleDir = IdleDirections.RIGHT;
                animator.SetFloat("Horizontal", move.x);
            }
        }

        void SetIdleDirections()
        {
            switch (idleDir)
            {
                case IdleDirections.UP:
                    animator.SetFloat("FacingDir", 2f);
                    break;
                case IdleDirections.DOWN:
                    animator.SetFloat("FacingDir", 0f);
                    break;
                case IdleDirections.LEFT:
                    sr.flipX = true;
                    animator.SetFloat("FacingDir", 1f);
                    break;
                case IdleDirections.RIGHT:
                    sr.flipX = false;
                    animator.SetFloat("FacingDir", 1f);
                    break;
                default:
                    break;
            }
        }
    }
}