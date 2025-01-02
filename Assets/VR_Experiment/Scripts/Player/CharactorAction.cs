using MyVRSample;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Noah
{
    public class CharactorAction : MonoBehaviour
    {
        private GameObject autoGet;
        private PlayerSetting playerSetting;
        private bool isGrap = false;

        public bool IsGrap 
        {
            get { return isGrap; }
            set { isGrap = value; }

        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            playerSetting = GetComponent<PlayerSetting>();
        }

        // Update is called once per frame
        void Update()
        {
            // Button ������Ʈ 
            OnStorage();
            OnStorageLeft();
            LeftAct();
            LeftSelect();
            RightAct();
            RightSelect();

            // Active Button �ѹ��� ����(����)
            LeftStorageAct();
            // Active Button �ѹ��� ����(������)
            RightStorageAct();

            // Select Button �ѹ��� ����
            LeftSelectInputDown();
            RightSelectInputDown();
            LeftSelectInputUp();
            RightSelectInputUp();

            // ��ư ��ȣ�ۿ�
            LeftYButtonInputDown();
            RightBButtonInputDown();
            RightXInputDown();
        }

        void OnStorage()
        {
            if (InputActManager.Instance.IsStorage() && InputActManager.Instance.IsRightSelect())
            {
                // Right Select
                // A Ű �Է�
            }
        }

        void OnStorageLeft()
        {
            if (InputActManager.Instance.IsStorage() && InputActManager.Instance.IsLeftSelect())
            {
                // Left Select
                // A Ű �Է�
            }
        }

        void RightXInputDown()
        {
            if (InputActManager.Instance.IsStorage())
            {
                // X Ű �Է�
            }
        }

        void LeftAct()
        {
            if (InputActManager.Instance.IsLeftAct())
            {

            }
            else 
            {

            }
        }

        void LeftSelect()
        {
            if (InputActManager.Instance.IsLeftSelect())
            {

            }
            else
            {

            }

        }

        void RightAct()
        {
            if (InputActManager.Instance.IsRightAct())
            {

            }
            else
            {

            }
        }
        void RightSelect()
        {
            if (InputActManager.Instance.IsRightSelect())
            {

            }
            else
            {

            }
        }

        void LeftStorageAct()
        {
            if (InputActManager.Instance.IsLeftStorage())
            {
                // ������Ʈ �ʵ�� ����
                GetBackStoeage();
            }
            if (InputActManager.Instance.IsLeftStorageRl())
            {
                // �κ��丮���� ������Ʈ ���� �� ������ ����
                
            }
        }

        void RightStorageAct()
        {
            if (InputActManager.Instance.IsRightStorage())
            {
                // ������Ʈ �ʵ�� ����
                Right_GetBackStoeage();
            }
            if (InputActManager.Instance.IsRightStorageRl())
            {
                // �κ��丮���� ������Ʈ ���� �� ������ ����
                
            }
        }

        // ���� Select ButtonDown
        void LeftSelectInputDown()
        {
            if (InputActManager.Instance.IsLeftSelectPress())
            {
                IsGrap = true;
            }
        }

        // ������ Select ButtonDown
        void RightSelectInputDown()
        {
            if (InputActManager.Instance.IsRightSelectPress())
            {
                IsGrap = true;
            }
        }

        // ���� Select ButtonUp
        void LeftSelectInputUp()
        {
            if (InputActManager.Instance.IsLeftSelectReleased())
            {
                IsGrap = false;
            }
        }

        // ������ Select ButtonUp
        void RightSelectInputUp()
        {
            if (InputActManager.Instance.IsRightSelectReleased())
            {
                IsGrap = false;
            }
        }

        #region ��ȣ�ۿ�
        void GetBackStoeage()
        {
            // WhichSelect
        }

        void Right_GetBackStoeage()
        {
            // Right WhichSelect
        }
        #endregion

        // ���� Y ��ư
        void LeftYButtonInputDown()
        {
            if (InputActManager.Instance.IsLeftYButtonDown())
            {
                Debug.Log("Y");
            }
        }

        void RightBButtonInputDown()
        {
            if (InputActManager.Instance.IsRightBButtonDown())
            {
                Debug.Log("B");
            }
        }
    }
}

