using System;
using UnityEngine;

public abstract class SkillSO : ScriptableObject
{
    [Header("아이콘")]
    public Sprite Icon;
    [Header("이름")]
    public string Name;
    [Header("레벨 제한")]
    public int LevelLimit;
    [Header("현재 레벨")]
    public int CurrentLevel = 1;
    [Header("설명")]
    public string SkillDesc;
    [Header("쿨타임")] 
    public float CoolT;

    public float CurrentT;

    public virtual void Initialize()
    {
        CurrentT = CoolT;
        CurrentLevel = 1;
    }

    protected abstract void Active();

    public abstract void Upgrade();
    public virtual void UpdateCoolT(float dt)
    {
        CurrentT -= dt;
        if (CurrentT <= 0)
        {
            Active();
            CurrentT = CoolT;
        }
    }
}
