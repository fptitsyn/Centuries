using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interact
{
    public class GrabSystem : MonoBehaviour
    {
        [SerializeField]
        private Camera characterCamera;
        [SerializeField]
        private Transform slot;

        private PickableItem _pickedItem;
        void Update()
        {

        }
    }
}
