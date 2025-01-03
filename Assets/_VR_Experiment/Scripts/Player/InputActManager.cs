using UnityEngine.InputSystem;
using UnityEngine;

public class InputActManager : MonoBehaviour
{
    public static InputActManager Instance;

    public InputActionProperty leftAction;
    public InputActionProperty rightAction;
    public InputActionProperty leftSelect;
    public InputActionProperty rightSelect;

    // MainMenuUI Control
    public InputActionProperty leftJoystick;
    public InputActionProperty rightJoyStick;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


    }
    public bool IsLeftAct()
    {
        float L_act = leftAction.action.ReadValue<float>();

        return L_act > 0.1f;
    }
    public bool IsRightAct()
    {
        float R_act = rightAction.action.ReadValue<float>();

        return R_act > 0.1f;
    }
    public bool IsLeftSelect()
    {
        float L_Select = leftSelect.action.ReadValue<float>();

        return L_Select > 0.1f;
    }
    public bool IsRightSelect()
    {
        float R_Select = rightSelect.action.ReadValue<float>();

        return R_Select > 0.1f;
    }

    public bool IsLeftStorage()
    {
        bool left_storage = leftAction.action.WasPressedThisFrame();

        return left_storage;
    }

    public bool IsLeftStorageRl()
    {
        bool left_storage = leftAction.action.WasReleasedThisFrame();

        return left_storage;
    }

    public bool IsRightStorage()
    {
        bool right_storage = rightAction.action.WasPressedThisFrame();

        return right_storage;
    }

    public bool IsRightStorageRl()
    {
        bool right_storage = rightAction.action.WasReleasedThisFrame();

        return right_storage;
    }

    public bool IsLeftSelectPress()
    {
        bool leftPr = leftSelect.action.WasPressedThisFrame();

        return leftPr;
    }

    public bool IsLeftSelectReleased()
    {
        bool leftRl = leftSelect.action.WasReleasedThisFrame();

        return leftRl;
    }

    public bool IsRightSelectPress()
    {
        bool rightPr = rightSelect.action.WasPressedThisFrame();

        return rightPr;
    }

    public bool IsRightSelectReleased()
    {
        bool rightRl = rightSelect.action.WasReleasedThisFrame();

        return rightRl;
    }

    public bool JoystickButtonDown()
    {
        Vector2 leftIsJoyDown = leftJoystick.action.ReadValue<Vector2>();
        Vector2 rightIsJoyDown = rightJoyStick.action.ReadValue<Vector2>();

        return leftIsJoyDown.y < 0f || rightIsJoyDown.y < 0f;
    }

    public bool JoystickButtonUp()
    {
        Vector2 leftIsJoyUp = leftJoystick.action.ReadValue<Vector2>();
        Vector2 rightIsJoyUp = rightJoyStick.action.ReadValue<Vector2>();

        return leftIsJoyUp.y > 0f || rightIsJoyUp.y > 0f;
    }
}
