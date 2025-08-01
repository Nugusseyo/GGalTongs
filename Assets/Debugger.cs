using UnityEngine;
using UnityEngine.InputSystem;

public class Debugger : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            ExpManager.Instance.ExpUp(1000);
            Debug.Log($"CurrentLevel = {ExpManager.Instance.CurrentLevel}");
        }
    }
}
