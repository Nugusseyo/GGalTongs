using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO[] _skill;

    public void Click()
    {
        if (SkillManager.Instance.SkillList.Contains(_skill[1]))
        {
            _skill[1].Upgrade();
            
        }
        else if (!SkillManager.Instance.SkillList.Contains(_skill[1]))
        {
            SkillManager.Instance.Add(_skill[1]);
        }
    }
}

