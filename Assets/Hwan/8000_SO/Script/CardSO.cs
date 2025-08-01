using UnityEngine;

public class CardSO : ScriptableObject
{
    [Header("�̸�")]
    public string Name;
    [Header("����")]
    public string Desc;
    [Header("�׸�")]
    public Sprite Image;
    [Header("������ �ִ� ī�� ��")]
    public int CurrentLevel;
    [Header("���ۡ�����")]
    public int StartLevel = 1;

    public void First()
    {
        CurrentLevel = StartLevel;
    }
}