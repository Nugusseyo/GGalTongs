using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO _skill;
    [SerializeField] private SkillSO _skill1;

    public void Click()
    {
        if (SkillManager.Instance.SkillList.Count == 0)
        {
            SkillManager.Instance.Add(_skill);
        }
        if (SkillManager.Instance.SkillList.Count == 1)
        {
            SkillManager.Instance.Add(_skill1);
        }
    }
}
