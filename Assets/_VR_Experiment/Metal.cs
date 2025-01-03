using UnityEngine;

namespace InnerSight
{
    public enum Element
    {
        Barium,
        Copper,
        Lithium,
        Magnesium,
        Potassium,
    }

    /// <summary>
    /// �Ҳ� ������ ������ �ݼ�
    /// </summary>
    public class Metal : MonoBehaviour
    {
        // �ʵ�
        #region Variables
        [SerializeField]
        private Element element;
        public Element Element => element;
        #endregion
    }
}