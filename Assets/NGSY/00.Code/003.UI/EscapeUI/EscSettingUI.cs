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
        playerInput.OnEscKeyPress += GameStopHandle;
        playerInput.OnMoveKeyPress += SettingUIShowHandle;
        settingUI.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        playerInput.OnEscKeyPress -= GameStopHandle;
        playerInput.OnEscKeyPress -= SettingUIShowHandle;
    }

    private void SettingUIShowHandle()
    {
        settingUI.SetActive(playerInput.isGamePaused);
    }


    private void GameStopHandle()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            playerInput.isGamePaused = false;
            settingUI.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            playerInput.isGamePaused = true;
            settingUI.gameObject.SetActive(true);
        }
    }
}
