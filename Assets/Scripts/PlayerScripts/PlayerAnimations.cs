using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentDirections
{
    DOWN,
    RIGHT,
    UP,
    LEFT
}
public class PlayerAnimations : MonoBehaviour
{
    public SpriteRenderer sr;
    public HairSwitcher hs;

    CurrentDirections currDir = CurrentDirections.DOWN;

    public Animator animator;

    public void Direction(Vector2 move)
    {
        LookAtDirection(move);
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

    public bool IsAttacking()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed_Attack"))
        {
            return true;
        }
        return false;
    }

    // Rotate the character depending on if it's moving left or right
    void LookAtDirection(Vector2 move)
    {
            
        animator.SetFloat("Speed", move.sqrMagnitude);

        if (move.x < 0)
        {
            currDir = CurrentDirections.LEFT;
        }
        else if (move.x > 0)
        {
            currDir = CurrentDirections.RIGHT;
        }
        else if (move.y > 0)
        {
            currDir = CurrentDirections.UP;
        }
        else if (move.y < 0)
        {
            currDir = CurrentDirections.DOWN;
        }
            
    }

    // Determines which direction the character will face when coming to a stop
    void SetCurrentDirection()
    {
        switch (currDir)
        {
            case CurrentDirections.DOWN:
                hs.SwitchHair(0);
                animator.SetFloat("FacingDir", 0f);
                break;
            case CurrentDirections.RIGHT:
                hs.SwitchHair(1);
                animator.SetFloat("FacingDir", 1f);
                break;
            case CurrentDirections.UP:
                hs.SwitchHair(2);
                animator.SetFloat("FacingDir", 2f);
                break;
            case CurrentDirections.LEFT:
                hs.SwitchHair(3);
                animator.SetFloat("FacingDir", 3f);
                break;
            default:
                break;
        }
    }

    public CurrentDirections GetCurrentDirection()
    {
        return currDir;
    }
}
