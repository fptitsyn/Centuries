using UnityEngine;

namespace Enemies
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int Run = Animator.StringToHash("IsRunning");
        private static readonly int Walk = Animator.StringToHash("IsWalking");

        public void LaunchAttack()
        {
            // int attackTrigger = Animator.StringToHash("Attack1");
            int attackTrigger = Animator.StringToHash("Attack" + Random.Range(1, 5));
            _animator.SetTrigger(attackTrigger);
        }

        public void IsRunning(bool condition)
        {
            _animator.SetBool(Run, condition);
        }

        public void IsWalking(bool condition)
        {
            _animator.SetBool(Walk, condition);
        }

        public void Die()
        {
            Debug.Log("Anim");
            int deathTrigger = Animator.StringToHash("Death" + Random.Range(1, 4));
            _animator.SetTrigger(deathTrigger);
        }
    }
}

