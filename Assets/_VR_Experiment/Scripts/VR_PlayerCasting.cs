using UnityEngine;

namespace MyVrSample
{
    //정면에 있는 충돌체와의 거리 구하기
    public class VR_PlayerCasting : MonoBehaviour
    {

        #region Variables
        public static float distanceFromTarget = Mathf.Infinity;
        [SerializeField] private float toTarget;    //거리 숫자 보기
        #endregion

        private void Start()
        {
            //초기화
            //distanceFromTarget = Mathf.Infinity;
        }

        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                distanceFromTarget = hit.distance;
                toTarget = distanceFromTarget;
            }
        }

        //Gimo 그리기 : 카메라 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
            }
        }
    }
}