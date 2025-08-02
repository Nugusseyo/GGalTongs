using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EscSettingUI : MonoBehaviour
{
    public PlayerInputSO playerInput;
    public GameObject settingUI;

    private void Start()
    {
        if (playerInput == null) return;
        playerInput.OnEscKeyPress += GameStopHandle;
        playerInput.OnMoveKeyPress += SettingUIShowHandle;
        settingUI.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        if (playerInput == null) return;
        playerInput.OnEscKeyPress -= GameStopHandle;
        playerInput.OnMoveKeyPress -= SettingUIShowHandle;
    }

    private void SettingUIShowHandle()
    {
        if (settingUI == null) return;
        settingUI.SetActive(playerInput.isGamePaused);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    private void GameStopHandle()
    {
        if (settingUI == null) return;

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            playerInput.isGamePaused = false;
            settingUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            playerInput.isGamePaused = true;
            settingUI.SetActive(true);
        }
    }
}
