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
    [SerializeField] private SkillCardSO[] _skills;

    [Header("스탯 SO들")]
    [SerializeField] private StatCardSO[] _stats;

    public Dictionary<Card, CardSetter> CardDictionary { get; private set; } = new Dictionary<Card, CardSetter>();

    public void Awake()
    {
        MakeCard();
        ChooseCard();
    }

    private void MakeCard()
    {
        CardDictionary.Add(Card.SkillCard, Instantiate(_skillCard_Prefab.GetComponent<CardSetter>(), transform));
        CardDictionary.Add(Card.StatCard_1, Instantiate(_statCard_1_Prefab.GetComponent<CardSetter>(), transform));
        CardDictionary.Add(Card.StatCard_2, Instantiate(_statCard_2_Prefab.GetComponent<CardSetter>(), transform));
    }

    private void ChooseCard()
    {
        SkillCardSO selectedSkill;
        StatCardSO selectedStat_1;
        StatCardSO selectedStat_2;

        selectedSkill = _skills[Random.Range(0, _skills.Length)];
        selectedStat_1 = _stats[Random.Range(0, _stats.Length)];
        do
        {
            selectedStat_2 = _stats[Random.Range(0, _stats.Length)];
        }
        while (selectedStat_2 != selectedStat_1);

        CardSetting(selectedSkill, selectedStat_1, selectedStat_2);
    }
    private void CardSetting(SkillCardSO selectedSkill, StatCardSO selectedStat_1, StatCardSO selectedStat_2)
    {
        CardDictionary[Card.SkillCard].SetCard(selectedSkill);
        CardDictionary[Card.StatCard_1].SetCard(selectedStat_1);
        CardDictionary[Card.StatCard_2].SetCard(selectedStat_2);
    }
}
