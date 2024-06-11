using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class OpenDoorSound : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip clip2;
    public GameObject doorObject;

    public void OpenDoor()
    {
        AudioSource audioSource = doorObject.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void MetalOpenDoor()
    {
        AudioSource audioSource = doorObject.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip2);
        }
    }
}
