using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TorchItemUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI torchItemGUI;
    [field: SerializeField] public int CurretTorchItem { get; private set; } = 0;
    public static TorchItemUi Instance { get; private set; }
    public event Action OnApplyCount;
    private void Awake()
    {
        OnApplyCount+=CoountApply;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        OnApplyCount?.Invoke();
    }
    public void AddTorchItme(int getTorch)
    {
        getTorch = Mathf.Clamp(getTorch, 0, 100);
        CurretTorchItem += getTorch;
        OnApplyCount?.Invoke();
    }
    public void UseTorchItem(int useTorch)
    {
        useTorch = Mathf.Clamp(useTorch, 0, 100);
        CurretTorchItem -= useTorch;
        OnApplyCount?.Invoke();
    }
    private void CoountApply()
    {
        torchItemGUI.text = CurretTorchItem.ToString();
    }
    private void OnDestroy()
    {
        OnApplyCount-=OnApplyCount;
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
