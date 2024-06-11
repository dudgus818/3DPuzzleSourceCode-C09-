using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // 손전등을 나타내는 Light 컴포넌트를 저장할 변수
    public Light flashlight;

    // 손전등의 초기 상태 (켜짐/꺼짐)를 설정할 변수
    private bool isOn = false;

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // F 키를 눌렀을 때 손전등의 상태를 토글
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashlight();
        }
    }

    // 손전등의 상태를 토글하는 함수
    void ToggleFlashlight()
    {
        // 현재 상태를 반대로 변경
        isOn = !isOn;

        // 손전등의 활성화 상태를 변경된 상태에 맞게 설정
        flashlight.enabled = isOn;
    }
}
