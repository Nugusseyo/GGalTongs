using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float CurrentCoolT;
    [Header("액티브 카운트")]
    public int ActiveCount;

    private bool _isSubs = false;
    
    public virtual void Initialize()
    {
        Debug.Log("Initialize");
        CurrentCoolT = CoolT;
        if (!_isSubs)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            _isSubs = true;
        }
    }

    public virtual void ResetSkillData()
    {
        CurrentLevel = 1;
        CurrentCoolT = CoolT;
    }
    
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        ResetSkillData();
    }

    protected abstract void Active();

    public abstract void Upgrade();
    public virtual void UpdateCoolT(float dt)
    {
        CurrentCoolT -= dt;
        if (CurrentCoolT <= 0)
        {
            Active();
            CurrentCoolT = CoolT;
        }
    }
}
