using UnityEngine;
using System;
using System.Collections;

public class PlayerCondition : MonoBehaviour
{
    public Condition condition;
    public UiCondition uiCondition;

    private PlayerController playerController;

    [Header ("Sprint")]
    public float recoveryDelay = 5.0f; // 스태미나 회복 지연 시간 (초)
    private bool isRecovering = false;

    Condition sprintStamina { get { return uiCondition.sprintStamina; }}

    void Start()
    {
        condition = CharacterManager.Instance.GetComponent<Condition>();
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        HandleStamina();
    }

    public void HandleStamina()
    {
        if (playerController.isSprinting)
        {
            SubtractSprintStamina();

            if (sprintStamina.curValue <= 0)
            {
                sprintStamina.curValue = 0;
                playerController.isSprinting = false;  // 스태미나가 바닥나면 스프린트 중지
                isRecovering = true;
                StartCoroutine(RecoverStaminaAfterDelay());
            }
        }
        else if(!isRecovering)
        {
            AddSprintStamina();
        }
    }

    private IEnumerator RecoverStaminaAfterDelay()
    {
        yield return new WaitForSeconds(recoveryDelay);
        isRecovering = false;
    }

    public void AddSprintStamina()
    {
        if (!playerController.isSprinting)
        {
            sprintStamina.Add(sprintStamina.addValue * Time.deltaTime);
        }
    }

    public void SubtractSprintStamina()
    {
        sprintStamina.Subtract(sprintStamina.subtractValue * Time.deltaTime);
    }
}
