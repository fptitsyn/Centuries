using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        public int health;

        [SerializeField] private float minWalkableDistance;
        [SerializeField] private float maxWalkableDistance;

        [SerializeField] private float walkingSpeed;
        [SerializeField] private float runningSpeed;

        [SerializeField] private float reachedPointDistance;

        [SerializeField] private GameObject roamTarget;

        [SerializeField] private float targetFollowRange;
        [SerializeField] private float stopTargetFollowingRange;

        [SerializeField] private EnemyAttack enemyAttack;

        [SerializeField] private AIDestinationSetter aiDestinationSetter;

        [SerializeField] private EnemyAnimator enemyAnimator;

        [SerializeField] private AIPath aiPath;

        private Player _player;

        private EnemyState _currentState;

        private Vector3 _roamPosition;

        private void Start()
        {
            _player = FindObjectOfType<Player>();

            _currentState = EnemyState.Roaming;

            _roamPosition = GenerateRoamPosition();
        }

        private void Update()
        {
            switch (_currentState)
            {
                case EnemyState.Roaming:
                    roamTarget.transform.position = _roamPosition;

                    if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= reachedPointDistance)
                    {
                        _roamPosition = GenerateRoamPosition();
                    }

                    aiDestinationSetter.target = roamTarget.transform;

                    TryFindingPlayer();

                    enemyAnimator.IsWalking(true);
                    enemyAnimator.IsRunning(false);

                    aiPath.maxSpeed = walkingSpeed;

                    break;

                case EnemyState.Following:
                    aiDestinationSetter.target = _player.transform;

                    enemyAnimator.IsWalking(false);
                    enemyAnimator.IsRunning(true);

                    aiPath.maxSpeed = runningSpeed;

                    if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < enemyAttack.AttackRange)
                    {
                        enemyAnimator.IsWalking(false);
                        enemyAnimator.IsRunning(false);

                        if (enemyAttack.CanAttack)
                        {
                            enemyAnimator.LaunchAttack();
                            //Debug.Log(enemyAttack.CanAttack);
                            //Debug.Log("1");
                        }                      
                    }                 

                    if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= stopTargetFollowingRange)
                    {
                        _currentState = EnemyState.Roaming;
                    }

                    break;
            }
        }

        private void TryFindingPlayer()
        {
            if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= targetFollowRange)
            {
                _currentState = EnemyState.Following;
            }
        }

        private Vector3 GenerateRoamPosition()
        {
            var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();

            return roamPosition;
        }

        private float GenerateRandomWalkableDistance()
        {
            var randomDistance = Random.Range(minWalkableDistance, maxWalkableDistance);

            return randomDistance;
        }

        private Vector3 GenerateRandomDirection()
        {
            var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

            return newDirection.normalized;
        }

        public void StopMovement()
        {
            aiPath.canMove = false;
        }

        public void StartMovement()
        {
            aiPath.canMove = true;
        }
    }

    public enum EnemyState
    {
        Roaming,
        Following
    }
}
