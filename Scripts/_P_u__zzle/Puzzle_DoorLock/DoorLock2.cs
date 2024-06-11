using UnityEngine;
using TMPro;

public class DoorLock2 : MonoBehaviour
{
    public TMP_Text resultText;  // ����� ǥ���� �ؽ�Ʈ �ʵ�
    private string input = "";  // ����� �Է��� ������ ���ڿ�
    private string correctPassword = "CANIS"; // ������ �׽�Ʈ ��й�ȣ
    public InteractableObject interactableObject;
    public GameObject irongrating;

    private PlayerController playerController;

    private void Start()
    {
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
    }

    // ���� ��ư�� Ŭ���� �� ȣ��Ǵ� �޼���
    public void OnNumberButtonClick(string number)
    {
        if (input.Length < 5)
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
            Animator animator = irongrating.GetComponent<Animator>();

            if (animator != null && animator.isActiveAndEnabled)
            {
                Debug.Log("Setting Animator Bool to true");
                animator.SetBool("IronIsOpen", true);
            }
            GameManager.instance.ToggleCursor();

            AudioManager audioManager = FindAnyObjectByType<AudioManager>();
            OpenDoorSound openDoorSound = GetComponent<OpenDoorSound>();
            if (audioManager != null)
            {
                audioManager.OkSound();
            }
            if (openDoorSound != null)
            {
                Debug.Log("MetalOpenDoor");
                openDoorSound.MetalOpenDoor();
            }
            Invoke("DisablePuzzleUI", 0.5f);

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
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("��Ȱ��ȭ ����.");
        }
    }
}
