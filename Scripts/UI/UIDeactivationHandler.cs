using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ϲ� UI ��Ȱ��ȭ�ϸ� �ͽ� �Ѿƿ��� ��ũ��Ʈ
public class UIDeactivationHandler : MonoBehaviour
{
   
    public AudioClip soundEffect;  // ȿ����
    private AudioSource audioSource;  // ����� �ҽ�
    private bool isDeactivated = false;

    void Start()
    {
        // ����� �ҽ��� UI ������Ʈ�� �ƴ� �ٸ� ������Ʈ�� �߰��մϴ�.
        GameObject audioSourceObject = new GameObject("BackGroundMusicSource");
        audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        DontDestroyOnLoad(audioSourceObject);  // ����� �ҽ� ������Ʈ�� �ı����� �ʵ��� ����
    }

    void OnDisable()
    {
        if (!isDeactivated)
        {
            isDeactivated = true;
            
            PlaySoundEffect();
        }
    }

    void OnEnable()
    {
        isDeactivated = false;
    }


    void PlaySoundEffect()
    {
        audioSource.Play();
    }
}
