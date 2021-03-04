﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        
    float speed = 5;

    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;

    Character character;
    [SerializeField] CharacterController controller;

    public PlayerStatuses playerStatus;
    public PlayerAnimations playerAnimations;
    public PlayerActions playerActions;
    public PlayerInventory playerInventory;

    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerAnimations.IsAttacking() && !playerInventory.isInteracting)
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
}