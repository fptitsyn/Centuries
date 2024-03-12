using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interact
{
    [RequireComponent(typeof(Rigidbody))]
    public class PickableItem : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
