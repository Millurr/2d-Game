using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
  
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
            LookAtDirection(move.x);
        }

        // Rotate the character depending on if it's moving left or right
        void LookAtDirection(float xDirection)
        {
            animator.SetFloat("Vertical", move.y);
            animator.SetFloat("Speed", move.sqrMagnitude);
            if (xDirection < 0)
            {
                sr.flipX = true;
                animator.SetFloat("Horizontal", xDirection);
            }
            if (xDirection > 0)
            {
                sr.flipX = false;
                animator.SetFloat("Horizontal", xDirection);
            }
            
        }
    }
}