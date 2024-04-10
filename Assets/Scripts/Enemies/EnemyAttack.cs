using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;

        public float AttackRange => attackRange;

        public void TryAttackingPlayer()
        {

        }
    }
}
