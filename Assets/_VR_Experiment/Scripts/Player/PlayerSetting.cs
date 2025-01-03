using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PlayerSetting : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 StartPos => startPos;    

    public XRRayInteractor rayInteractor;
    public XRRayInteractor right_rayInteractor;

    private void Start()
    {
        startPos = new Vector3(0f, 1.36f, 0f);
    }

    private void Update()
    {
        if (transform.GetChild(0).position.y <= 1.35f || transform.GetChild(0).position.y > 1.36f)
        {
            PlayerPos();
        }
    }

    void PlayerPos()
    {
        transform.GetChild(0).position = new Vector3(transform.position.x, startPos.y, transform.position.z);
    }
}
