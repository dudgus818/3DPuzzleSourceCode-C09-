using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BthManger : MonoBehaviour
{
    public GameObject StatPanel;
    public GameObject GameStopPanel;
    public GameObject PostProcess;

    private PlayerController playerController;

    public void StartPanel()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        playerController = CharacterManager.Instance.Player.GetComponent<PlayerController>();
        GameManager.instance.ToggleCursor();
        StatPanel.SetActive(false);
        PostProcess.SetActive(true);

        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
    }

    public void SettingOn()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
    }

    public void ExitGame()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
        Application.Quit();
    }

    public void MainMenuGame()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        SceneManager.LoadScene("MainScene");
        if (audioManager != null)
        {
            audioManager.PlayClickSound();
        }
    }
}
