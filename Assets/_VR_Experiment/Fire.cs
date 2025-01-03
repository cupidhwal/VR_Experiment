using UnityEngine;
using UnityEngine.VFX;

namespace InnerSight
{
    /// <summary>
    /// ºÒ²É ¹ÝÀÀ¿¡ µû¶ó »ö±òÀ» Á¶Á¤ÇÏ´Â Å¬·¡½º
    /// </summary>
    public class Fire : MonoBehaviour
    {
        // ÇÊµå
        #region Variables
        private VisualEffect effect;

        private Vector4 default_InnerColor = new(1f, 0.5f, 0f, 1f); // ±âº» ¼ÓºÒ²É
        private Vector4 default_OuterColor = new(1f, 0f, 0f, 1f);   // ±âº» °ÑºÒ²É
        [SerializeField]
        private float intensity = 3;    // ¹à±â
        private Vector4 innerColor;     // ¼ÓºÒ²É
        private Vector4 outerColor;     // °ÑºÒ²É
        #endregion

        // ¶óÀÌÇÁ »çÀÌÅ¬
        #region Life Cycle
        private void Start()
        {
            effect = GetComponentInChildren<VisualEffect>();
            SetColor(default_InnerColor, default_OuterColor, intensity);
        }
        #endregion

        // ¸Þ¼­µå
        #region Methods
        private void SetColor(Vector4 innerColor, Vector4 outerColor, float intensity)
        {
            // Fire_InsideColor ÇÁ·ÎÆÛÆ¼ ¼³Á¤
            if (effect.HasVector4("Fire_InsieColor"))
                effect.SetVector4("Fire_InsieColor", innerColor * intensity);

            // Fire_OutsideColor ÇÁ·ÎÆÛÆ¼ ¼³Á¤
            if (effect.HasVector4("Fire_OutsideColor"))
                effect.SetVector4("Fire_OutsideColor", outerColor * intensity);
        }

        private void DefineColor(Element element)
        {
            switch (element)
            {
                case Element.Barium:
                    innerColor = new Vector4(0.3f, 1f, 0.4f, 1f);   // °ÑºÒ²É (¹àÀº ³ì»ö)
                    outerColor = new Vector4(0.2f, 0.8f, 0.3f, 1f); // ¼ÓºÒ²É (³ë¶õºû ³ì»ö)
                    break;

                case Element.Copper:
                    innerColor = new Vector4(0.1f, 0.7f, 0.5f, 1f);   // °ÑºÒ²É (Ã»·Ï»ö)
                    outerColor = new Vector4(0.1f, 0.5f, 0.8f, 1f);   // ¼ÓºÒ²É (Çª¸¥»ö)
                    break;

                case Element.Lithium:
                    innerColor = new Vector4(1f, 0.3f, 0.3f, 1f);   // °ÑºÒ²É (¹àÀº »¡°£»ö)
                    outerColor = new Vector4(0.6f, 0.1f, 0.1f, 1f); // ¼ÓºÒ²É (¾îµÎ¿î »¡°£»ö)
                    break;

                case Element.Magnesium:
                    innerColor = new Vector4(1f, 1f, 1f, 1f);       // °ÑºÒ²É (¹àÀº Èò»ö)
                    outerColor = new Vector4(0.8f, 0.9f, 1f, 1f);   // ¼ÓºÒ²É (Çª¸¥ Èò»ö)
                    break;

                case Element.Potassium:
                    innerColor = new Vector4(0.6f, 0f, 1f, 1f);     // °ÑºÒ²É (¹àÀº º¸¶ó»ö)
                    outerColor = new Vector4(0.4f, 0f, 0.8f, 1f);   // ¼ÓºÒ²É (¾îµÎ¿î ÀÚÁÖ»ö)
                    break;

                default:
                    innerColor = default_InnerColor;
                    outerColor = default_OuterColor;
                    break;
            }
        }
        #endregion

        // ÀÌº¥Æ® ¸Þ¼­µå
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