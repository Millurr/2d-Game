using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class PlayerActions : MonoBehaviour
    {
        public float damage = 20f;
        public Transform[] attackPoints;
        public float attackRange;
        public LayerMask enemyLayers;
        public PlayerAnimations pa;
        public StatsObject playerStats;

        public void Attack(float dmg)
        {

            if (pa == null)
                return;

            // pa.GetCurrentDirection() gets the current direction the player is facing to postiong the hit sphere in the proper location
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[(int)pa.GetCurrentDirection()].position, playerStats.attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies)
            {
                if (enemy == null)
                    return;

                enemy.GetComponent<Enemy>().TakeDamage(playerStats.attackDamage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(attackPoints[(int)pa.GetCurrentDirection()].position, attackRange);
        }
    }
}