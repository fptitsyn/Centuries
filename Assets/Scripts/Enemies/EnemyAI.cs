using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float minWalkableDistance;
        [SerializeField] private float maxWalkableDistance;

        [SerializeField] private float reachedPointDistance;

        [SerializeField] private GameObject roamTarget;

        [SerializeField] private float targetFollowRange;
        [SerializeField] private float stopTargetFollowingRange;

        [SerializeField] private EnemyAttack enemyAttack;

        [SerializeField] private AIDestinationSetter aiDestinationSetter;

        private Player player;

        private EnemyState currentState;

        private Vector3 roamPostition;

        private void Start()
        {
            player = FindObjectOfType<Player>();

            currentState = EnemyState.Roaming;

            roamPostition = GenerateRoamPosition();
        }

        private void Update()
        {
            switch (currentState)
            {
                case EnemyState.Roaming:
                    roamTarget.transform.position = roamPostition;

                    if (Vector3.Distance(gameObject.transform.position, roamPostition) <= reachedPointDistance)
                    {
                        roamPostition = GenerateRoamPosition();
                    }

                    aiDestinationSetter.target = roamTarget.transform;

                    TryFindingPlayer();

                    break;

                case EnemyState.Following:
                    aiDestinationSetter.target = player.transform;

                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) < enemyAttack.AttackRange)
                    {
                        enemyAttack.TryAttackingPlayer();
                    }

                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= stopTargetFollowingRange)
                    {
                        currentState = EnemyState.Roaming;
                    }

                    break;
            }
        }

        private void TryFindingPlayer()
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= targetFollowRange)
            {
                currentState = EnemyState.Following;
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
    }

    public enum EnemyState
    {
        Roaming,
        Following
    }
}
