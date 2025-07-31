using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

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
        SkillList.Add(skillSo);
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
