using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SkillCardSO", menuName = "CardSO/SkillCardSO")]
public class SkillCardSO : ScriptableObject
{
    [Header("�̸�")]
    public string Name;
    [Header("����")]
    public string Desc;
    [Header("�׸�")]
    public Sprite Image;
    [Header("������ �ִ� ī�� ��")]
    public int Level;
    [Header("��ųSO")]
    public SkillSO Skill;
}