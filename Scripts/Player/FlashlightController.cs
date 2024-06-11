using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    // �������� ��Ÿ���� Light ������Ʈ�� ������ ����
    public Light flashlight;

    // �������� �ʱ� ���� (����/����)�� ������ ����
    private bool isOn = false;

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // F Ű�� ������ �� �������� ���¸� ���
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashlight();
        }
    }

    // �������� ���¸� ����ϴ� �Լ�
    void ToggleFlashlight()
    {
        // ���� ���¸� �ݴ�� ����
        isOn = !isOn;

        // �������� Ȱ��ȭ ���¸� ����� ���¿� �°� ����
        flashlight.enabled = isOn;
    }
}
