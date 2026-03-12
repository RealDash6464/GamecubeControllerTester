using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TriggerInputDisplay : MonoBehaviour
{
    [SerializeField] Image triggerButton;

    [SerializeField] string triggerButtonName;

    [SerializeField] TextMeshProUGUI triggerValueTextUi;
    PlayerInput playerInput;

    InputAction a_t;
    void OnEnable()
    {
        a_t.started += context => inputDisplayTrigger(context);
        a_t.performed += context => inputDisplayTrigger(context);
        a_t.canceled += context => inputDisplayTrigger(context);
    }

    void OnDisable()
    {
        a_t.started -= context => inputDisplayTrigger(context);
        a_t.performed -= context => inputDisplayTrigger(context);
        a_t.canceled -= context => inputDisplayTrigger(context);
    }
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        a_t = playerInput.actions[triggerButtonName];
    }



    void inputDisplayTrigger(InputAction.CallbackContext context)
    {
        triggerButton.fillAmount = context.ReadValue<float>();
        triggerValueTextUi.text = context.ReadValue<float>().ToString("F7");
    }

}
