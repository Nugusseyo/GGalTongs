using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    public bool isGamePaused = false;
    public InputSystem_Actions _inputSys;

    public Action OnMoveKeyPress;
    public Action OnEscKeyPress;
    public Vector2 MovementKey { get; private set; }

    private void OnEnable()
    {
        if(_inputSys == null)
        {
            _inputSys = new InputSystem_Actions();
            _inputSys.Player.SetCallbacks(this);
        }
        _inputSys.Player.Enable();
    }

    private void OnDisable()
    {
        _inputSys.Player.SetCallbacks(null);
        _inputSys.Player.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (isGamePaused) return;
        MovementKey = context.ReadValue<Vector2>();
        OnMoveKeyPress?.Invoke();
    }

    public void OnSetting(InputAction.CallbackContext context)
    {
        OnEscKeyPress?.Invoke();
    }
}
