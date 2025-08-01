using UnityEngine;

public class CardSO : ScriptableObject
{
    [Header("이름")]
    public string Name;
    [Header("설명")]
    public string Desc;
    [Header("그림")]
    public Sprite Image;
    [Header("가지고 있는 카드 수")]
    public int Level;
}
