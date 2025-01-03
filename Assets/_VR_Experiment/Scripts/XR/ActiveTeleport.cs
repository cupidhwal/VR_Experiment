using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVRSample
{
    public class ActiveTeleport : MonoBehaviour
    {
        public GameObject leftRay_TP;
        public GameObject rightRay_TP;

        public InputActionProperty leftAction;
        public InputActionProperty rightAction;

        public XRRayInteractor leftGrab;
        public XRRayInteractor rightGrab;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ShowRay();
        }

        void ShowRay()
        {
            float leftValue = leftAction.action.ReadValue<float>();
            float rightValue = rightAction.action.ReadValue<float>();

            bool isLeftHover = leftGrab.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNomal, out int leftNum, out bool leftValid);
            bool isRightHover = rightGrab.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNomal, out int rightNum, out bool rightValid);


            if (leftValue > 0.1f && !isLeftHover)
            {
                leftRay_TP.SetActive(true);
            }
            else
            {
                leftRay_TP.SetActive(false);
            }
            if (rightValue > 0.1f && !isRightHover)
            {
                rightRay_TP.SetActive(true);
            }
            else
            {
                rightRay_TP.SetActive(false);
            }

        }
    }

}
