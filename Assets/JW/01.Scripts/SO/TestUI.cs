using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO[] _skill;

    public void Click()
    {
        for (int i = 0; i < 3; i++)
        {
            SkillManager.Instance.Add(_skill[i]);
        }
        // int i = 0;
        // if (SkillManager.Instance.SkillList.Contains(_skill[i]))
        // {
        //     _skill[i].Upgrade();
        //     Debug.Log($"Upgrade , {SkillManager.Instance.SkillList.Contains(_skill[i])}");
        // }
        // else if (!SkillManager.Instance.SkillList.Contains(_skill[i]))
        // {
        //     i++;
        //     Debug.Log(12);
        //     SkillManager.Instance.Add(_skill[i]);
        }
    }

