using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public enum CurrentDirections
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    public class PlayerAnimations : MonoBehaviour
    {
        public SpriteRenderer sr;

        CurrentDirections currDir = CurrentDirections.DOWN;

        public Animator animator;

        public void Direction(Vector2 move)
        {
            LookAtDirection(move);
            Debug.Log(move);
            SetCurrentDirection();
        }

        public void Sprint(float mag)
        {
            if (mag < 6)
            {
                animator.speed = 1f;
            }
            else if (mag > 6)
            {
                animator.speed = 2f;
            }
        }

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }

        // Rotate the character depending on if it's moving left or right
        void LookAtDirection(Vector2 move)
        {
            animator.SetFloat("Vertical", move.y);
            animator.SetFloat("Speed", move.sqrMagnitude);

            if (move.x > -1f && sr.flipX == true)
            {
                sr.flipX = false;
            }

            if (move.y > 0)
            {
                currDir = CurrentDirections.UP;
            }

            if (move.y < 0)
            {
                currDir = CurrentDirections.DOWN;
            }

            if (move.x < 0)
            {
                if (move.y.Equals(0f))
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }

                currDir = CurrentDirections.LEFT;
                animator.SetFloat("Horizontal", move.x);
            }

            if (move.x > 0)
            {
                currDir = CurrentDirections.RIGHT;
                animator.SetFloat("Horizontal", move.x);
            }
        }

        // Determines which direction the character will face when coming to a stop
        void SetCurrentDirection()
        {
            switch (currDir)
            {
                case CurrentDirections.UP:
                    animator.SetFloat("FacingDir", 2f);
                    break;
                case CurrentDirections.DOWN:
                    animator.SetFloat("FacingDir", 0f);
                    break;
                case CurrentDirections.LEFT:
                    sr.flipX = true;
                    animator.SetFloat("FacingDir", 1f);
                    break;
                case CurrentDirections.RIGHT:
                    sr.flipX = false;
                    animator.SetFloat("FacingDir", 1f);
                    break;
                default:
                    break;
            }
        }
    }
}
