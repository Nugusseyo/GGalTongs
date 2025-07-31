using UnityEngine;

[CreateAssetMenu(fileName = "SkillCardSO", menuName = "SO/SkillCardSO")]
public class SkillCardSO : ScriptableObject
{
    [Header("�̸�")]
    public string SkillName;
    [Header("����")]
    public string Desc;
    [Header("�׸�")]
    public Sprite Sprite;
    [Header("������ �ִ� ī�� ��")]
    public int Level;
    [Header("��ųSO")]
    public SkillSO Skill;
}