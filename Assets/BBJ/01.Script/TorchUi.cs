using System;
using UnityEditor;
using UnityEngine;

public class TorchUi : MonoBehaviour
{
    [field: SerializeField] public int TorchCount { get; private set; } = 0;
    public static TorchUi Instance { get; private set; }
    public event Action OnCountApply;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    public void GettingTorch(int getTorch)
    {
        TorchCount += getTorch;
        OnCountApply?.Invoke();
    }
    public void UseTorch(int useTorch)
    {
        TorchCount -= useTorch;
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
