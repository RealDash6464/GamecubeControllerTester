using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonInputDisplay : MonoBehaviour
{
    [SerializeField] GameObject buttonA;
    [SerializeField] GameObject buttonB;
    [SerializeField] GameObject buttonX;
    [SerializeField] GameObject buttonY;
    [SerializeField] GameObject buttonZ;
    [SerializeField] GameObject buttonStart;

    PlayerInput playerInput;

    InputAction a_a;
    InputAction a_b;
    InputAction a_x;
    InputAction a_y;
    InputAction a_z;
    InputAction a_start;

    void OnEnable()
    {
        a_a.started += context => inputDisplayButton(context, buttonA);
        a_b.started += context => inputDisplayButton(context, buttonB);
        a_x.started += context => inputDisplayButton(context, buttonX);
        a_y.started += context => inputDisplayButton(context, buttonY);
        a_z.started += context => inputDisplayButton(context, buttonZ);
        a_start.started += context => inputDisplayButton(context, buttonStart);

        a_a.canceled += context => inputDisplayButton(context, buttonA);
        a_b.canceled += context => inputDisplayButton(context, buttonB);
        a_x.canceled += context => inputDisplayButton(context, buttonX);
        a_y.canceled += context => inputDisplayButton(context, buttonY);
        a_z.canceled += context => inputDisplayButton(context, buttonZ);
        a_start.canceled += context => inputDisplayButton(context, buttonStart);
    }

    void OnDisable()
    {
        a_a.started -= context => inputDisplayButton(context, buttonA);
        a_b.started -= context => inputDisplayButton(context, buttonB);
        a_x.started -= context => inputDisplayButton(context, buttonX);
        a_y.started -= context => inputDisplayButton(context, buttonY);
        a_z.started -= context => inputDisplayButton(context, buttonZ);
        a_start.started -= context => inputDisplayButton(context, buttonStart);

        a_a.canceled -= context => inputDisplayButton(context, buttonA);
        a_b.canceled -= context => inputDisplayButton(context, buttonB);
        a_x.canceled -= context => inputDisplayButton(context, buttonX);
        a_y.canceled -= context => inputDisplayButton(context, buttonY);
        a_z.canceled -= context => inputDisplayButton(context, buttonZ);
        a_start.canceled -= context => inputDisplayButton(context, buttonStart);
    }

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        a_a = playerInput.actions["Button A"];
        a_b = playerInput.actions["Button B"];
        a_x = playerInput.actions["Button X"];
        a_y = playerInput.actions["Button Y"];
        a_z = playerInput.actions["Button Z"];
        a_start = playerInput.actions["Start"];
    }

    void inputDisplayButton(InputAction.CallbackContext state, GameObject button)
    {
        if (state.started)
        {
            button.SetActive(true);
        }

        if (state.canceled)
        {
            button.SetActive(false);
        }
    }


}
