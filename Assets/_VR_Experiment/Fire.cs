using UnityEngine;
using UnityEngine.VFX;

namespace InnerSight
{
    /// <summary>
    /// �Ҳ� ������ ���� ������ �����ϴ� Ŭ����
    /// </summary>
    public class Fire : MonoBehaviour
    {
        // �ʵ�
        #region Variables
        private VisualEffect effect;

        private Vector4 default_InnerColor = new(1f, 0.5f, 0f, 1f); // �⺻ �ӺҲ�
        private Vector4 default_OuterColor = new(1f, 0f, 0f, 1f);   // �⺻ �ѺҲ�
        [SerializeField]
        private float intensity = 3;    // ���
        private Vector4 innerColor;     // �ӺҲ�
        private Vector4 outerColor;     // �ѺҲ�
        #endregion

        // ������ ����Ŭ
        #region Life Cycle
        private void Start()
        {
            effect = GetComponentInChildren<VisualEffect>();
            SetColor(default_InnerColor, default_OuterColor, intensity);
        }
        #endregion

        // �޼���
        #region Methods
        private void SetColor(Vector4 innerColor, Vector4 outerColor, float intensity)
        {
            // Fire_InsideColor ������Ƽ ����
            if (effect.HasVector4("Fire_InsieColor"))
                effect.SetVector4("Fire_InsieColor", innerColor * intensity);

            // Fire_OutsideColor ������Ƽ ����
            if (effect.HasVector4("Fire_OutsideColor"))
                effect.SetVector4("Fire_OutsideColor", outerColor * intensity);
        }

        private void DefineColor(Element element)
        {
            switch (element)
            {
                case Element.Barium:
                    innerColor = new Vector4(0.3f, 1f, 0.4f, 1f);   // �ѺҲ� (���� ���)
                    outerColor = new Vector4(0.2f, 0.8f, 0.3f, 1f); // �ӺҲ� (����� ���)
                    break;

                case Element.Copper:
                    innerColor = new Vector4(0.1f, 0.7f, 0.5f, 1f);   // �ѺҲ� (û�ϻ�)
                    outerColor = new Vector4(0.1f, 0.5f, 0.8f, 1f);   // �ӺҲ� (Ǫ����)
                    break;

                case Element.Lithium:
                    innerColor = new Vector4(1f, 0.3f, 0.3f, 1f);   // �ѺҲ� (���� ������)
                    outerColor = new Vector4(0.6f, 0.1f, 0.1f, 1f); // �ӺҲ� (��ο� ������)
                    break;

                case Element.Magnesium:
                    innerColor = new Vector4(1f, 1f, 1f, 1f);       // �ѺҲ� (���� ���)
                    outerColor = new Vector4(0.8f, 0.9f, 1f, 1f);   // �ӺҲ� (Ǫ�� ���)
                    break;

                case Element.Potassium:
                    innerColor = new Vector4(0.6f, 0f, 1f, 1f);     // �ѺҲ� (���� �����)
                    outerColor = new Vector4(0.4f, 0f, 0.8f, 1f);   // �ӺҲ� (��ο� ���ֻ�)
                    break;

                default:
                    innerColor = default_InnerColor;
                    outerColor = default_OuterColor;
                    break;
            }
        }
        #endregion

        // �̺�Ʈ �޼���
        #region Event Methods
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<Metal>(out var metal))
                DefineColor(metal.Element);
            Debug.Log(metal.Element);
            Debug.Log(innerColor);
            Debug.Log(outerColor);
            Debug.Log(intensity);
            SetColor(innerColor, outerColor, intensity);
        }

        private void OnTriggerExit(Collider other)
        {
            SetColor(default_InnerColor, default_OuterColor, intensity);
        }
        #endregion
    }
}