using UnityEngine;
using UnityEngine.UI;

namespace Noah
{
    public class CharactorAction : MonoBehaviour
    {
        [SerializeField]
        private Button nextButton;

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
            // A Ű �Է�
            //nextButton.onClick.Invoke();
        }

        void OnStorageLeft()
        {
            
            // A Ű �Է�
            //nextButton.onClick.Invoke();
        }

        void RightXInputDown()
        {
            
            // X Ű �Է�
            //nextButton.onClick.Invoke();
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
            nextButton.onClick.Invoke();
        }

        void Right_GetBackStoeage()
        {
            // Right WhichSelect
            nextButton.onClick.Invoke();
        }
        #endregion

        // ���� Y ��ư
        void LeftYButtonInputDown()
        {
            /*if (InputActManager.Instance.IsLeftYButtonDown())
            {
                Debug.Log("Y");
            }*/
        }

        void RightBButtonInputDown()
        {
            /*if (InputActManager.Instance.IsRightBButtonDown())
            {
                Debug.Log("B");
            }*/
        }
    }
}

