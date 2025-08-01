using UnityEngine;

public class TestUI : MonoBehaviour
{
    [SerializeField] private SkillSO[] _skill;

    public void Click()
    {
        int i = 0;
        if (SkillManager.Instance.SkillList.Contains(_skill[i]))
        {
            _skill[i].Upgrade();
            Debug.Log($"Upgrade , {SkillManager.Instance.SkillList.Contains(_skill[i])}");
        }
        else if (!SkillManager.Instance.SkillList.Contains(_skill[i]))
        {
            i++;
            SkillManager.Instance.Add(_skill[i]);
        }
    }
}
