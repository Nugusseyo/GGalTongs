using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCard : MonoBehaviour
{
    [Header("카드 프리팹")]
    [SerializeField] private GameObject _skillCard_Prefab;
    [SerializeField] private GameObject _statCard_1_Prefab;
    [SerializeField] private GameObject _statCard_2_Prefab;

    [Header("스킬 SO들")]
    [SerializeField] private SkillSO[] _skills;

    [Header("스탯 SO들")]
    [SerializeField] private StatCardSO[] _stats;

    public Dictionary<int, CardSetter> CardDictionary { get; private set; } = new Dictionary<int, CardSetter>();

    public void Awake()
    {
        MakeCard();
        ChooseCard();
        MoveCard();
    }

    private void MakeCard()
    {
        CardDictionary.Add(1, Instantiate(_skillCard_Prefab.GetComponent<CardSetter>(), transform));
        CardDictionary.Add(2, Instantiate(_statCard_1_Prefab.GetComponent<CardSetter>(), transform));
        CardDictionary.Add(3, Instantiate(_statCard_2_Prefab.GetComponent<CardSetter>(), transform));

        CardDictionary.Add(4, Instantiate(_skillCard_Prefab.GetComponent<CardSetter>(), CardDictionary[1].transform));
        CardDictionary.Add(5, Instantiate(_statCard_1_Prefab.GetComponent<CardSetter>(), CardDictionary[2].transform));
        CardDictionary.Add(6, Instantiate(_statCard_2_Prefab.GetComponent<CardSetter>(), CardDictionary[3].transform));

        CardDictionary.Add(7, Instantiate(_skillCard_Prefab.GetComponent<CardSetter>(), CardDictionary[1].transform));
        CardDictionary.Add(8, Instantiate(_statCard_1_Prefab.GetComponent<CardSetter>(), CardDictionary[2].transform));
        CardDictionary.Add(9, Instantiate(_statCard_2_Prefab.GetComponent<CardSetter>(), CardDictionary[3].transform));
    }

    private void ChooseCard()
    {
        for (int i = 1; i <= 3; i++)
        {
            int s2 = 0;
            int s3 = 1;

            CardDictionary[1 + ((i - 1) * 2)].SetCard(_skills[Random.Range(0, _skills.Length)]);

            s2 = Random.Range(0, _stats.Length);
            CardDictionary[2 + ((i - 1) * 2)].SetCard(_stats[s2]);
            do
            {
                s3 = Random.Range(0, _stats.Length);
                CardDictionary[i * 3].SetCard(_stats[s3]);
            }
            while (s3 == s2);
        }
    }

    private void MoveCard()
    {
        for (int i = 4; i <= CardDictionary.Count; i++)
        {
            CardDictionary[i].GetComponent<RectTransform>().localScale = Vector3.one;
            CardDictionary[i].GetComponent<SelectMove>().enabled = false;
        }
        CardDictionary[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);
        CardDictionary[5].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);
        CardDictionary[6].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);

        CardDictionary[7].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
        CardDictionary[8].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
        CardDictionary[9].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
    }
}
