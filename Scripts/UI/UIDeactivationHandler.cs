using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//지하방 UI 비활성화하면 귀신 쫓아오는 스크립트
public class UIDeactivationHandler : MonoBehaviour
{
   
    public AudioClip soundEffect;  // 효과음
    private AudioSource audioSource;  // 오디오 소스
    private bool isDeactivated = false;

    void Start()
    {
        // 오디오 소스를 UI 오브젝트가 아닌 다른 오브젝트에 추가합니다.
        GameObject audioSourceObject = new GameObject("BackGroundMusicSource");
        audioSource = audioSourceObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        DontDestroyOnLoad(audioSourceObject);  // 오디오 소스 오브젝트가 파괴되지 않도록 설정
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
