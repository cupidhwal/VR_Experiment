using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVRSample
{
    public class AnimateHandOnInput : MonoBehaviour
    {
        // input 입력값 처리
        public InputActionProperty pinch;
        public InputActionProperty grip;



        Animator animator;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            HandAnimation();

        }

        void HandAnimation()
        {
            float pinchValue = pinch.action.ReadValue<float>();
            float gripValue = grip.action.ReadValue<float>();

            animator.SetFloat("Trigger", pinchValue);
            animator.SetFloat("Grip", gripValue);
        }
        
    }

}
