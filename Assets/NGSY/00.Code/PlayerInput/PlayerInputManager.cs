using System;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInputSO playerInputSO;
    public static PlayerInputManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AcceptAllInputs()
    {
        playerInputSO._inputSys.Player.Enable();
    }

    public void StopAllInputs()
    {
        playerInputSO._inputSys.Player.Disable();
    }
}
