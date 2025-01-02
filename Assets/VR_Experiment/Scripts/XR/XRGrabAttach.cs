using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFPS
{
    public class XRGrabAttach : XRGrabInteractable
    {
        public Transform attach_R;
        public Transform attach_L;

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = attach_L;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = attach_R;
            }

            base.OnSelectEntering(args);
        }
    }
}