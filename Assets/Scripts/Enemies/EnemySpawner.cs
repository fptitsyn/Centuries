using Audio;
using UI;
using UnityEngine;

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
            AudioManager.Instance.PlayMusic("Battle Music " + Random.Range(1, 4));
            AudioManager.Instance.StartCheer();
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
            int randomX = Random.Range(minX, maxX);
            while (randomX is > -15 and < 0)
            {
                randomX = Random.Range(minX, maxX);
            }

            int randomZ = Random.Range(minY, maxY);
            while (randomZ is > -10 and < 0)
            {
                randomZ = Random.Range(minX, maxX);
            }
            
            var startPos = new Vector3(randomX, height, randomZ);

            return startPos;
        }
    }
}

