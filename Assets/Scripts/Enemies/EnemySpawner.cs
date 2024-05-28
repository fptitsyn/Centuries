using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        public int count;

        [SerializeField] private GameObject enemyPrefab;

        [SerializeField] private float spawnInterval;

        [SerializeField] private int minX;
        [SerializeField] private int maxX;
        [SerializeField] private int minY;
        [SerializeField] private int maxY;

        [SerializeField] private float height;

        public int maxCount;

        private float _currentSpawnTimer;

        public static EnemySpawner Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            maxCount = BattleManager.Instance.BattleData.EnemyAmount;
        }

        private void Update()
        {
            _currentSpawnTimer += Time.deltaTime;

            if (_currentSpawnTimer >= spawnInterval)
            {
                if (count < maxCount)
                {
                    var enemyInstance = Instantiate(enemyPrefab);

                    var newPosition = GenerateStartPosition();

                    enemyInstance.transform.position = newPosition;

                    _currentSpawnTimer = 0;
                    count++;
                }              
            }
        }

        private Vector3 GenerateStartPosition()
        {
            var startPos = new Vector3(Random.Range(minX, maxX), height, Random.Range(minY, maxY));

            return startPos;
        }
    }
}

