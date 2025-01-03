using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray를 관리하는 클래스
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;          //텔레포트 왼쪽 Ray 오브젝트
        public GameObject rightTeleportRay;         //텔레포트 오른쪽 Ray 오브젝트

        public InputActionProperty leftActivate;    //왼쪽 컨트롤러의 Activate 입력
        public InputActionProperty rightActivate;   //오른쪽 컨트롤러의 Activate 입력

        public XRRayInteractor leftGrapLay;
        public XRRayInteractor rightGrapLay;
        #endregion

        private void Update()
        {
            float leftActivateValue = leftActivate.action.ReadValue<float>();
            float rightActivateValue = rightActivate.action.ReadValue<float>();

            bool isLeftRayHovering = leftGrapLay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal,
                out int leftNumber, out bool leftValid);
            bool isRightRayHovering = rightGrapLay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal,
                out int rightNumber, out bool rightValid);

            leftTeleportRay.SetActive(!isLeftRayHovering && leftActivateValue > 0.1f);
            rightTeleportRay.SetActive(!isRightRayHovering && rightActivateValue > 0.1f);
        }
    }
}