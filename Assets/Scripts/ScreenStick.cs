using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenStick : MonoBehaviour
{
    [SerializeField] GameObject stick;

    [SerializeField] string stickInputName;

    [SerializeField] float range = 50;

    [SerializeField] TextMeshProUGUI stickPosTextUi;

    float stickMoveX;
    float stickMoveY;

    PlayerInput playerInput;

    InputAction a_move;

    UnityEngine.Vector2 stickPos;

    UnityEngine.Vector2 stickOriginPos;

    void OnEnable()
    {
        a_move.started += onMoveStickUI;
        a_move.performed += onMoveStickUI;
        a_move.canceled += onMoveStickUI;
    }


    void OnDisable()
    {
        a_move.started -= onMoveStickUI;
        a_move.performed -= onMoveStickUI;
        a_move.canceled -= onMoveStickUI;
    }

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        a_move = playerInput.actions[stickInputName];
    }

    void Start()
    {
        stickOriginPos = stick.GetComponent<RectTransform>().anchoredPosition;
    }

    void onMoveStickUI(InputAction.CallbackContext context)
    {
        stickPosTextUi.text = context.ReadValue<UnityEngine.Vector2>().ToString("F2");
        stickMoveX = context.ReadValue<UnityEngine.Vector2>().x;
        stickMoveY = context.ReadValue<UnityEngine.Vector2>().y;

        stickPos = new UnityEngine.Vector2(stickMoveX, stickMoveY) * range;

        if (stickMoveX == 0 || stickMoveY == 0)
        {
            stick.GetComponent<RectTransform>().anchoredPosition = stickOriginPos;
        }

        stick.GetComponent<RectTransform>().anchoredPosition = stickPos;

    }
}
