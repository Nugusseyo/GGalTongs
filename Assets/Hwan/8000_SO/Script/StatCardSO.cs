using UnityEngine;

[CreateAssetMenu(fileName = "StatCardSO", menuName = "Scriptable Objects/StatCardSO")]
public class StatCardSO : ScriptableObject
{
    [Header("�̸�")]
    public string SkillName;
    [Header("����")]
    public string Desc;
    [Header("�׸�")]
    public Sprite Sprite;
    [Header("������ �ִ� ī�� ��")]
    public int Level;
    [Header("������ �� ����")]
    public PlayerStat stat;
    [Header("�ö󰡴� ���")]
    public float BonusValue;
}
