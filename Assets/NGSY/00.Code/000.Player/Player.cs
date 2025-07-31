using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }
    
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponentInChildren<PlayerMovement>();
        PlayerInput.OnMoveKeyPress += HandleOnMoveKeyPress;
    }


    private void OnDestroy()
    {
        PlayerInput.OnMoveKeyPress -= HandleOnMoveKeyPress;
    }
    private void HandleOnMoveKeyPress()
    {
        SetUpMovementInput();
    }

    private void SetUpMovementInput()
    {
        _playerMovement.SetMoveDir(PlayerInput.MovementKey);
    }
}
