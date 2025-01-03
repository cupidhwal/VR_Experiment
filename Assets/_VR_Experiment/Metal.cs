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
    /// 불꽃 반응에 투입할 금속
    /// </summary>
    public class Metal : MonoBehaviour
    {
        // 필드
        #region Variables
        [SerializeField]
        private Element element;
        public Element Element => element;
        #endregion
    }
}