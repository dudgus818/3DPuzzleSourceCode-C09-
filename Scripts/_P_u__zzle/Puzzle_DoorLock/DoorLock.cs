using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DoorLock : MonoBehaviour
{
    public TMP_Text resultText;  // ����� ǥ���� �ؽ�Ʈ �ʵ�
    private string input = "";  // ����� �Է��� ������ ���ڿ�
    public string correctPassword = "1234"; // ������ �׽�Ʈ ��й�ȣ
    public DoorController doorController;
    public InteractableObject interactableObject;

    private PlayerController playerController;

    private void Start()
    {
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
    }

    // ���� ��ư�� Ŭ���� �� ȣ��Ǵ� �޼���
    public void OnNumberButtonClick(string number)
    {
        if (input.Length < 4)
        {
            input += number;
            resultText.text = input;
        }
        
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.ButtonSound();
        }
    }

    // 'C' ��ư�� Ŭ���� �� ȣ��Ǵ� �޼��� (�ʱ�ȭ)
    public void OnClearButtonClick()
    {
        input = "";
        resultText.text = "0";

        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.ButtonSound();
        }

    }

    // ��й�ȣ Ȯ�� �޼���
    public void OnCheckPassword()
    {
        if (input == correctPassword)
        {
            resultText.text = "Access";
            doorController.isOpen = true;
            GameManager.instance.ToggleCursor();
            Invoke("DisablePuzzleUI", 0.5f);

            AudioManager audioManager = FindAnyObjectByType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.OkSound();
            }

            OpenDoorSound openDoorSound = GetComponent<OpenDoorSound>();
            if (openDoorSound != null)
            {
                openDoorSound.OpenDoor();
            }

        }
        else
        {
            resultText.text = "ERROR";
            input = ""; // �Է� �ʱ�ȭ

            AudioManager audioManager = FindAnyObjectByType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.ErrorSound();
            }

        }
    }
    void DisablePuzzleUI()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("��Ȱ��ȭ ����.");
        }
    }
}
