using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    public List<SkillSO> SkillList = new List<SkillSO>();
    private float _time;
    public static SkillManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Add(SkillSO skillSo)
    {
        if (!SkillList.Contains(skillSo))
        {
           skillSo.Initialize();
           skillSo.ResetSkillData();
           skillSo.CurrentLevel = 1;
           
           SkillList.Add(skillSo); 
        }
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(0);
        }
        float dt = Time.deltaTime;
        if (SkillList != null)
        {
            for (int i = 0; i < SkillList.Count; i++)
            {
                SkillList[i].UpdateCoolT(dt);
            }
        }
    }
}
