using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool canBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            if (other.gameObject.GetComponent<EnemyAI>().health - damage <= 0)
            {
                other.gameObject.GetComponent<EnemyAI>().health = 0;
                Destroy(other.gameObject.transform.parent.gameObject);
                EnemySpawner.Instance.count--;
                if (EnemySpawner.Instance.count == 0)
                {
                    SceneManager.LoadScene(4);
                }
            }
            else
            {
                other.gameObject.GetComponent<EnemyAI>().health -= damage;
            }
        }
        else if (other.gameObject.CompareTag("Weapon"))
        {
            if (canBlock || other.gameObject.GetComponent<Weapon>().canBlock)
            {
                Debug.Log("Block");
            }
        }
    }
}
