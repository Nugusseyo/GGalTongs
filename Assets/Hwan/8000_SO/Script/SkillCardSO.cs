using UnityEngine;

[CreateAssetMenu(fileName = "SkillCardSO", menuName = "SO/SkillCardSO")]
public class SkillCardSO : ScriptableObject
{
    [Header("이름")]
    public string SkillName;
    [Header("설명")]
    public string Desc;
    [Header("그림")]
    public Sprite Sprite;
    [Header("가지고 있는 카드 수")]
    public int Level;
    [Header("스킬SO")]
    public SkillSO Skill;
}