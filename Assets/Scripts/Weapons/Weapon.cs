using System.Collections;
using Audio;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private bool canBlock;

        private void OnTriggerEnter(Collider other)
        {
            if (canBlock)
            {
                return;
            }

            damage = Random.Range(damage / 2 + 1, damage + damage / 2);
            
            GameObject hit = other.gameObject;
            if (hit.CompareTag("Enemy"))
            {
                GameObject enemy = hit.transform.parent.gameObject;
                if (enemy.GetComponent<EnemyAI>().health == 0)
                {
                    return;
                }
                AudioManager.Instance.PlaySfx("Sword Hit " + Random.Range(1, 6));
                Debug.Log("enemy");
                if (enemy.GetComponent<EnemyAI>().health - damage <= 0)
                {
                    enemy.GetComponent<EnemyAI>().health = 0;
                    EnemySpawner.Instance.count--;
                    EnemySpawner.Instance.maxCount--;
                    if (EnemySpawner.Instance.maxCount == 0)
                    {
                        StartCoroutine(WinFight());
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
                    AudioManager.Instance.PlaySfx("Sword Hit " + Random.Range(1, 6));
                }
            }
            else if (hit.CompareTag("Player"))
            {
                EnemyAI enemy = gameObject.GetComponentInParent<EnemyAI>();
                if (!enemy.IsAttacking)
                {
                    Debug.Log("nah");
                    return;
                }
                
                AudioManager.Instance.PlaySfx("Sword Hit " + Random.Range(1, 6));
                Player.Player player = hit.GetComponentInChildren<Player.Player>();
                Debug.Log("player hit");
                player.TakeDamage(damage);
            }
        }

        private IEnumerator WinFight()
        {
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.StopCheer();
            yield return new WaitForSeconds(1f);
            AudioManager.Instance.PlaySfx("Victory SFX");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(5);
        }
    }
}
