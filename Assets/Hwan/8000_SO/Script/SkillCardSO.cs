using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SkillCardSO", menuName = "CardSO/SkillCardSO")]
public class SkillCardSO : ScriptableObject
{
    [Header("이름")]
    public string Name;
    [Header("설명")]
    public string Desc;
    [Header("그림")]
    public Sprite Image;
    [Header("가지고 있는 카드 수")]
    public int Level;
    [Header("스킬SO")]
    public SkillSO Skill;
}