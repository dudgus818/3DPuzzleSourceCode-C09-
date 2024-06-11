using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicBox : MonoBehaviour
{
    void Start()
    {

        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayMusicBox();
        }
        else
        {
            audioManager.StopMusicBoxPlay();
        }
        return;
    }
}
