using TMPro;
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

    public SkillSO Skill { get; private set; }

    public PlayerStat Stat { get; private set; }

    public void SetCard(SkillSO skill)
    {
        Image.sprite = skill.Icon;
        Desc.text = skill.SkillDesc;
        Name.text = skill.Name;
        Level.text = $"���� : {skill.CurrentLevel}";
        Skill = skill;
    }
    public void SetCard(StatCardSO stat)
    {
        Image.sprite = stat.Image;
        Desc.text = stat.Desc;
        Name.text = stat.Name;
        Level.text = $"���� : {stat.Level}";
        Stat = stat.Stat;
    }
}
