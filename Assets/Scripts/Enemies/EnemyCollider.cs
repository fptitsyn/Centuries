using UnityEngine;

namespace Enemies
{
    public class EnemyCollider : MonoBehaviour
    {
        private const string WEAPON_TAG = "Weapon";

        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float force;

        private void OnTriggerEnter(Collider otherCollider)
        {
            if (!otherCollider.CompareTag(WEAPON_TAG))
            {
                return;
            }

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * force);
        }
    }
}