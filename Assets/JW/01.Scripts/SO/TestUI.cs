using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO _skill;
    [SerializeField] private SkillSO _skill1;

    public void Click()
    { 
        SkillManager.Instance.Add(_skill);
        if (SkillManager.Instance.SkillList.Contains(_skill))
        {
            _skill.Upgrade();
        }
    }
}
