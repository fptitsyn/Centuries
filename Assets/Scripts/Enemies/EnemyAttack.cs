using UnityEngine;

namespace Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float attackRange;
        [SerializeField] private float attackDamage;
        [SerializeField] private float attackCooldown;

        private float _timer;

        private Player _player;

        public bool CanAttack = true; 
        public float AttackRange => attackRange;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
        }

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

        public void TryAttackingPlayer(int attackDamage)
        {
            // _player.TakeDamage(attackDamage);

            CanAttack = false;
        }
    }
}
