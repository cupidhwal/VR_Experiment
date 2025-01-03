using Unity.XR.CoreUtils;
using UnityEngine;

namespace InnerSight
{
    public class Teacher : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        private void Update()
        {
            transform.LookAt(player);
        }
    }
}