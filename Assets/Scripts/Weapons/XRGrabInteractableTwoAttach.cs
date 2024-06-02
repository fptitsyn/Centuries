using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Weapons
{
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        public Transform rightAttachTransform;
        public Transform leftAttachTransform;

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            if (args.interactorObject.transform.CompareTag("Left Hand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactorObject.transform.CompareTag("Right Hand"))
            {
                attachTransform = rightAttachTransform;
            }
            
            base.OnSelectEntering(args);
        }
    }
}