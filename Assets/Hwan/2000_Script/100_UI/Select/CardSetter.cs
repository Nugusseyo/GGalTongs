using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CardSetter : MonoBehaviour
{
    [field : SerializeField] public Image Image { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Desc { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Name { get; private set; }
    [field: SerializeField] public TextMeshProUGUI Level { get; private set; }

    public SkillSO Skill { get; private set; }

    public PlayerStat Stat { get; private set; }

    public void SetCard(SkillCardSO skill)
    {
        Image.sprite = skill.Image;
        Desc.text = skill.Desc;
        Name.text = skill.Name;
        Level.text = $"레벨 : {skill.Level}";
        Skill = skill.Skill;
    }
    public void SetCard(StatCardSO stat)
    {
        Image.sprite = stat.Image;
        Desc.text = stat.Desc;
        Name.text = stat.Name;
        Level.text = $"레벨 : {stat.Level}";
        Stat = stat.Stat;
    }
}
