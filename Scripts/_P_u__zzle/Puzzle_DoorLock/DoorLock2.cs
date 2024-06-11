using UnityEngine;
using TMPro;

public class DoorLock2 : MonoBehaviour
{
    public TMP_Text resultText;  // 결과를 표시할 텍스트 필드
    private string input = "";  // 사용자 입력을 저장할 문자열
    private string correctPassword = "CANIS"; // 설정된 테스트 비밀번호
    public InteractableObject interactableObject;
    public GameObject irongrating;

    private PlayerController playerController;

    private void Start()
    {
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
    }

    // 숫자 버튼이 클릭될 때 호출되는 메서드
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

    // 'C' 버튼이 클릭될 때 호출되는 메서드 (초기화)
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

    // 비밀번호 확인 메서드
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
            input = ""; // 입력 초기화

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
            Debug.Log("비활성화 유지.");
        }
    }
}
