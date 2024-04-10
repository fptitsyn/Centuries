using System.Collections;
using System.Collections.Generic;
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

        private float currentSpawnTimer;

        private void Update()
        {
            currentSpawnTimer += Time.deltaTime;

            if (currentSpawnTimer >= spawnInterval)
            {
                var enemyInstance = Instantiate(enemyPrefab);

                var newPosition = GenerateStartPosition();

                enemyInstance.transform.position = newPosition;

                currentSpawnTimer = 0;
            }
        }

        private Vector3 GenerateStartPosition()
        {
            var startPos = new Vector3(Random.Range(minX, maxX), height, Random.Range(minY, maxY));

            return startPos;
        }
    }
}

