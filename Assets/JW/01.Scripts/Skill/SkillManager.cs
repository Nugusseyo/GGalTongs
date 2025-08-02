using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<SkillSO> skills;
    public List<SkillSO> SkillList = new List<SkillSO>();
    private float _time;
    public static SkillManager Instance;

    private void Awake()
    {
        foreach (var skill in skills)
        {
            skill.Initialize();
        }
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
           
           SkillList.Add(skillSo);

           skillSo.CurrentLevel = 1;
        }
    }

    private void Update()
    {
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
