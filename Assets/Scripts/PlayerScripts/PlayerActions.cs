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

        // Values for damage

        public void Attack(float dmg)
        {

            Debug.Log((int)pa.GetCurrentDirection());

            if (pa == null)
                return;

            Collider[] hitEnemies = Physics.OverlapSphere(attackPoints[(int)pa.GetCurrentDirection()].position, attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies)
            {
                if (enemy == null)
                    return;

                enemy.GetComponent<Enemy>().TakeDamage(20);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(attackPoints[(int)pa.GetCurrentDirection()].position, attackRange);
        }
    }
}