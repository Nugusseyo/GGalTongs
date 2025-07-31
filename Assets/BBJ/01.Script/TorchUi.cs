using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TorchUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI torchCountGUI;
    [field: SerializeField] public int TorchCount { get; private set; } = 0;
    public static TorchUi Instance { get; private set; }
    public event Action OnCountApply;
    private void Awake()
    {
        OnCountApply+=CoountApply;
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        
        OnCountApply?.Invoke();
    }
    public void GettingTorch(int getTorch)
    {
        TorchCount += getTorch;
        OnCountApply?.Invoke();
    }
    public void UseTorch(int useTorch)
    {
        TorchCount -= useTorch;
        OnCountApply?.Invoke();
    }
    private void CoountApply()
    {
        torchCountGUI.text = TorchCount.ToString();
    }
    private void OnDestroy()
    {
        OnCountApply-=OnCountApply;
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
