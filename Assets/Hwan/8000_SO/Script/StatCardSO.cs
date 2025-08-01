using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "CardSO/StatCardSO")]
public class StatCardSO : CardSO
{
    [Header("영향을 줄 스탯")]
    public PlayerStat Stat;
    [Header("올라가는 계수")]
    public float BonusValue;
}
