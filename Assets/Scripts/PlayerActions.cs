using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float damage = 20f;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;

    // Values for damage

    public void Attack(float dmg)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            if (enemy == null)
                return;

            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
