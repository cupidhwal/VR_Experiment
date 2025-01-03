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
            // Button 업데이트 
            OnStorage();
            OnStorageLeft();
            LeftAct();
            LeftSelect();
            RightAct();
            RightSelect();

            // Active Button 한번만 반응(왼쪽)
            LeftStorageAct();
            // Active Button 한번만 반응(오른쪽)
            RightStorageAct();

            // Select Button 한번만 반응
            LeftSelectInputDown();
            RightSelectInputDown();
            LeftSelectInputUp();
            RightSelectInputUp();

            // 버튼 상호작용
            LeftYButtonInputDown();
            RightBButtonInputDown();
            RightXInputDown();
        }

        void OnStorage()
        {
            // A 키 입력
            //nextButton.onClick.Invoke();
        }

        void OnStorageLeft()
        {
            
            // A 키 입력
            //nextButton.onClick.Invoke();
        }

        void RightXInputDown()
        {
            
            // X 키 입력
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
                // 오브젝트 필드로 꺼냄
                GetBackStoeage();
            }
            if (InputActManager.Instance.IsLeftStorageRl())
            {
                // 인벤토리에서 오브젝트 꺼낸 후 데이터 리셋
                
            }
        }

        void RightStorageAct()
        {
            if (InputActManager.Instance.IsRightStorage())
            {
                // 오브젝트 필드로 꺼냄
                Right_GetBackStoeage();
            }
            if (InputActManager.Instance.IsRightStorageRl())
            {
                // 인벤토리에서 오브젝트 꺼낸 후 데이터 리셋
                
            }
        }

        // 왼쪽 Select ButtonDown
        void LeftSelectInputDown()
        {
            if (InputActManager.Instance.IsLeftSelectPress())
            {
                IsGrap = true;
            }
        }

        // 오른쪽 Select ButtonDown
        void RightSelectInputDown()
        {
            if (InputActManager.Instance.IsRightSelectPress())
            {
                IsGrap = true;
            }
        }

        // 왼쪽 Select ButtonUp
        void LeftSelectInputUp()
        {
            if (InputActManager.Instance.IsLeftSelectReleased())
            {
                IsGrap = false;
            }
        }

        // 오른쪽 Select ButtonUp
        void RightSelectInputUp()
        {
            if (InputActManager.Instance.IsRightSelectReleased())
            {
                IsGrap = false;
            }
        }

        #region 상호작용
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

        // 왼쪽 Y 버튼
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

