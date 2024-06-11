using UnityEngine;
using System;
using System.Collections;

public class PlayerCondition : MonoBehaviour
{
    public Condition condition;
    public UiCondition uiCondition;

    private PlayerController playerController;

    [Header ("Sprint")]
    public float recoveryDelay = 5.0f; // ���¹̳� ȸ�� ���� �ð� (��)
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
                playerController.isSprinting = false;  // ���¹̳��� �ٴڳ��� ������Ʈ ����
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
