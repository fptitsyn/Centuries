using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        [SerializeField] private float spawnInterval;

        [SerializeField] private int minX;
        [SerializeField] private int maxX;
        [SerializeField] private int minY;
        [SerializeField] private int maxY;

        [SerializeField] private float height;

        private float _currentSpawnTimer;

        private void Update()
        {
            _currentSpawnTimer += Time.deltaTime;

            if (_currentSpawnTimer >= spawnInterval)
            {
                var enemyInstance = Instantiate(enemyPrefab);

                var newPosition = GenerateStartPosition();

                enemyInstance.transform.position = newPosition;

                _currentSpawnTimer = 0;
            }
        }

        private Vector3 GenerateStartPosition()
        {
            var startPos = new Vector3(Random.Range(minX, maxX), height, Random.Range(minY, maxY));

            return startPos;
        }
    }
}

