using System.Collections;
using Audio;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            
            GameObject hit = other.gameObject;
            if (hit.CompareTag("Enemy"))
            {
                GameObject enemy = hit.transform.parent.gameObject;
                if (enemy.GetComponent<EnemyAI>().health == 0)
                {
                    return;
                }
                Debug.Log("enemy");
                AudioManager.Instance.PlaySfx("Sword Hit");
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
                    AudioManager.Instance.PlaySfx("Sword Hit");
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
                
                Player.Player player = hit.GetComponentInChildren<Player.Player>();
                Debug.Log("player hit");
                AudioManager.Instance.PlaySfx("Sword Hit");
                player.TakeDamage(damage);
            }
        }

        private IEnumerator WinFight()
        {
            AudioManager.Instance.musicSource.Stop();
            yield return new WaitForSeconds(1f);
            AudioManager.Instance.PlaySfx("Victory SFX");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(5);
        }
    }
}
