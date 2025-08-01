using System;
using UnityEngine;
using UnityEngine.Events;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance; 
    [SerializeField] private ExpBar expBar;
    public int CurrentLevel { get; private set; }
    public int currentExp;
    public int goalExp;

    public UnityEvent levelUp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
        CurrentLevel = 0;
        currentExp = 0;
        goalExp = 10;

        expBar = GetComponentInChildren<ExpBar>();
    }

    public void ExpUp(int value)
    {
        currentExp += value;
        try
        {
            expBar.GrowingExpBar();
        }
        catch (Exception e)
        {
            Debug.Log("그로윙 엑스바가 실행되지 않음.");
            throw;
        }
        if (currentExp < goalExp) return;
        Debug.Log("넘어갔따");
        goalExp = 10 * (CurrentLevel + 1);
        CurrentLevel++;
        currentExp = 0;
        levelUp?.Invoke();
    }
}
