using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown;

        private float _timer;

        public bool CanAttack = true; 
        public float AttackRange => attackRange;

        private void Update()
        {
            UpdateCooldown();
        }

        private void UpdateCooldown()
        {
            if (CanAttack)
            {
                return;
            }

            _timer += Time.deltaTime;

            if (_timer < attackCooldown)
            {
                return;
            }

            CanAttack = true;

            _timer = 0f;
        }
    }
}
