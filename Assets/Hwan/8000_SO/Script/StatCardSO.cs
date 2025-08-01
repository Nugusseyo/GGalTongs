using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "CardSO/StatCardSO")]
public class StatCardSO : CardSO
{
    [Header("������ �� ����")]
    public PlayerStat Stat;
    [Header("�ö󰡴� ���")]
    public float BonusValue;
}
