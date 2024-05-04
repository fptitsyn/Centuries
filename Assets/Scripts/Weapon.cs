using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool canBlock;

    private void OnTriggerEnter(Collider other)
    {
        GameObject hit = other.gameObject;
        if (hit.CompareTag("Enemy"))
        {
            GameObject enemy = hit.transform.parent.gameObject;
            Debug.Log("enemy");
            if (enemy.GetComponent<EnemyAI>().health - damage <= 0)
            {
                enemy.GetComponent<EnemyAI>().health = 0;
                Destroy(enemy);
                EnemySpawner.Instance.count--;
                EnemySpawner.Instance.maxCount--;
                if (EnemySpawner.Instance.maxCount == 0)
                {
                    SceneManager.LoadScene(4);
                }
            }
            else
            {
                enemy.GetComponent<EnemyAI>().health -= damage;
            }
        }
        else if (hit.CompareTag("Weapon"))
        {
            if (canBlock || hit.GetComponent<Weapon>().canBlock)
            {
                Debug.Log("Block");
            }
        }
    }
}
