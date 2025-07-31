using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "CardSO/StatCardSO")]
public class StatCardSO : ScriptableObject
{
    [Header("�̸�")]
    public string Name;
    [Header("����")]
    public string Desc;
    [Header("�׸�")]
    public Sprite Image;
    [Header("������ �ִ� ī�� ��")]
    public int Level;
    [Header("������ �� ����")]
    public PlayerStat Stat;
    [Header("�ö󰡴� ���")]
    public float BonusValue;
}
