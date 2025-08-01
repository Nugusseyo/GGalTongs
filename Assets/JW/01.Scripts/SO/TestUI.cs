using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO _skill;
    [SerializeField] private SkillSO _skill1;
    [SerializeField] private SkillSO _skill2;

    public void Click()
    { 
        if (SkillManager.Instance.SkillList.Contains(_skill))
        {
            _skill.Upgrade();
            Debug.Log($"Upgrade , {SkillManager.Instance.SkillList.Contains(_skill)}");
        }
        else if (!SkillManager.Instance.SkillList.Contains(_skill))
        {
            SkillManager.Instance.Add(_skill);
        }
    }
}
