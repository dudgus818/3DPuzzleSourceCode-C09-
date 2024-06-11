using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;
    public AudioSource musicBoxSource;

    public AudioClip backgroundMusicClip;
    public AudioClip runMusicClip;
    public AudioClip clickSound;
    public AudioClip setSound;
    public AudioClip openInventorySound;
    public AudioClip musicboxSound;
    public AudioClip buttonSound;
    public AudioClip errorSound;
    public AudioClip okSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = clickSound;
            soundEffectSource.Play();
        }
    }
    public void PlayInventorySound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = openInventorySound;
            soundEffectSource.Play();
        }
    }
    public void setItemSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = setSound;
            soundEffectSource.Play();
        }
    }
    
    public void ButtonSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = buttonSound;
            soundEffectSource.Play();
        }
    }

    public void ErrorSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = errorSound;
            soundEffectSource.Play();
        }
    }

    public void OkSound()
    {
        if (clickSound != null)
        {
            soundEffectSource.clip = okSound;
            soundEffectSource.Play();
        }
    }

    public void BackGroundtMusic()
    {
        if (backgroundMusicClip != null)
        {
            backgroundMusicSource.clip = backgroundMusicClip;
            backgroundMusicSource.Play();
        }
    }

    public void RunMusic()
    {
        if (backgroundMusicClip != null)
        {
            backgroundMusicSource.clip = runMusicClip;
            backgroundMusicSource.Play();
        }
    }

    public void PlayMusicBox()
    {
        if (musicboxSound != null)
        {
            musicBoxSource.clip = musicboxSound;
            musicBoxSource.Play();
        }
    }

    public void StopMusicPlay()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }
    }
    public void StopMusicBoxPlay()
    {
        if (backgroundMusicSource != null)
        {
            musicBoxSource.Stop();
        }
    }

}
