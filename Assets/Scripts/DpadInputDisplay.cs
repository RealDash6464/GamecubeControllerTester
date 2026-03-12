using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;


public class DpadInputDisplay : MonoBehaviour
{
    [SerializeField] GameObject dpadUp;
    [SerializeField] GameObject dpadDown;
    [SerializeField] GameObject dpadLeft;
    [SerializeField] GameObject dpadRight;

    PlayerInput playerInput;

    InputAction a_move;

    UnityEngine.Vector2 dpadMove;

    void OnEnable()
    {
        a_move.started += context => inputDisplayDPad(context);
        a_move.performed += context => inputDisplayDPad(context);
        a_move.canceled += context => inputDisplayDPad(context);
    }

    void OnDisable()
    {
        a_move.started -= context => inputDisplayDPad(context);
        a_move.performed -= context => inputDisplayDPad(context);
        a_move.canceled -= context => inputDisplayDPad(context);
    }
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        a_move = playerInput.actions["D-Pad"];
    }

    void inputDisplayDPad(InputAction.CallbackContext context)
    {
        dpadMove = context.ReadValue<UnityEngine.Vector2>();

        dpadUp.SetActive(dpadMove.y > 0);
        dpadDown.SetActive(dpadMove.y < 0);
        dpadRight.SetActive(dpadMove.x > 0);
        dpadLeft.SetActive(dpadMove.x < 0);
    }
}
