using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

// 오브젝트를 잡을 때 offset 위치 설정
namespace MyVRSample
{
    public class XRGrabOffset : XRGrabInteractable
    {
        private GameObject attachPoint;

        private Vector3 initialLocalPos;
        private Quaternion initialLocalRot;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (attachPoint == null)
            {
                attachPoint = new GameObject("GrabOffset");
                attachPoint.transform.SetParent(transform, false);
                attachTransform = attachPoint.transform;
            }
            else
            {
                initialLocalPos = attachTransform.localPosition;
                initialLocalRot = attachTransform.localRotation;
            }
        }

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            if (args.interactorObject is XRDirectInteractor)
            {
                attachTransform.position = args.interactorObject.transform.position;
                attachTransform.rotation = args.interactorObject.transform.rotation;
            }
            else
            { 
                attachTransform.localPosition = initialLocalPos;
                attachTransform.rotation = initialLocalRot;
            }


            base.OnSelectEntering(args);
        }


    }
}