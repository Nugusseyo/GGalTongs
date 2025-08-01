using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO[] _skill;

    public void Click()
    {
        SkillManager.Instance.Add(_skill[1]);
        if (SkillManager.Instance.SkillList.Contains(_skill[1]))
        {
            _skill[1].Upgrade();
            Debug.Log($"Upgrade , {SkillManager.Instance.SkillList.Contains(_skill[1])}");
        }
        else if (!SkillManager.Instance.SkillList.Contains(_skill[1]))
        {
            Debug.Log(12);
            SkillManager.Instance.Add(_skill[1]);
        }
    }
}

