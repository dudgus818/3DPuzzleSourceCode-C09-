using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PianoPuzzle : MonoBehaviour
{
    public Button[] buttons;
    public GameObject doorObject;

    private int[] correctSequence = { 5, 3, 1, 6, 4, 7, 2 };
    private int currentButtonIndex = 0;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            int buttonNumber = i + 1;
            buttons[i].onClick.AddListener(() => OnButtonClicked(buttonIndex, buttonNumber));
        }
    }

    void OnButtonClicked(int buttonIndex, int buttonNumber)
    {
        Debug.Log("Button clicked: " + buttonNumber);

        if (buttonNumber == correctSequence[currentButtonIndex])
        {
            currentButtonIndex++;
            Debug.Log("Correct button pressed: " + buttonNumber);

            if (currentButtonIndex == correctSequence.Length)
            {
                Debug.Log("ok");
                OpenSecretDoor();
                currentButtonIndex = 0;
          
            }
        }
        else
        {
            currentButtonIndex = 0;
        }
    }
    void OpenSecretDoor()
    {
        Debug.Log("OpenSecretDoor called");

        AudioSource audioSource = doorObject.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            Debug.Log("OpenSec");
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not found in the children of doorObject.");
        }



        Animator animator = doorObject.GetComponent<Animator>();

        if (animator != null && animator.isActiveAndEnabled)
        {
            Debug.Log("Setting Animator Bool to true");
            animator.SetBool("Secret_is_Open", true);
        }
    }

}

