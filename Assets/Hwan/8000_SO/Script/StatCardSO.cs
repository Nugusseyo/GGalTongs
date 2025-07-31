using UnityEngine;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "Scriptable Objects/StatCardSO")]
public class StatCardSO : ScriptableObject
{
    [Header("이름")]
    public string SkillName;
    [Header("설명")]
    public string Desc;
    [Header("그림")]
    public Sprite Sprite;
    [Header("가지고 있는 카드 수")]
    public int Level;
    [Header("영향을 줄 스탯")]
    public PlayerStat stat;
    [Header("올라가는 계수")]
    public float BonusValue;
}
