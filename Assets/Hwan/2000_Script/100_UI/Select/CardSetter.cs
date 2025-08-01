using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CardSetter : MonoBehaviour
{
    [field: SerializeField] public bool IsSkill { get; private set; } = false;

    [field : SerializeField] public Image Image { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Desc { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Level { get; private set; }

    public Action Use { get; private set; }

    public SkillSO _nowSkill;
    private StatCardSO _nowStat;

    [SerializeField] private bool _isInside = true;

    public void SetCard(SkillSO skill)
    {
        _nowSkill = skill;


        if (_isInside)
        {
            Image.sprite = skill.Icon;
            Desc.text = skill.SkillDesc;
            Name.text = skill.Name;
            Level.text = $"���� : {skill.CurrentLevel}";
        }

        Use = () =>
        {
            if (SkillManager.Instance.SkillList.Contains(skill))
            {
                skill.Upgrade();
                Debug.Log($"Upgrade , {SkillManager.Instance.SkillList.Contains(skill)}");
            }
            else if (!SkillManager.Instance.SkillList.Contains(skill))
            {
                Debug.Log(12);
                SkillManager.Instance.Add(skill);
            }
        };
    }
    public void SetCard(StatCardSO stat)
    {
        _nowStat = stat;

        Image.sprite = stat.Image;
        Desc.text = stat.Desc;
        Name.text = stat.Name;
        Level.text = $"���� : {stat.CurrentLevel}";
        Use = stat.Apply;
    }

    public void Refresh()
    {
        if (_nowSkill == null)
        {
            SetCard(_nowStat);
        }
        else
        {
            SetCard(_nowSkill);
        }
    }
}
