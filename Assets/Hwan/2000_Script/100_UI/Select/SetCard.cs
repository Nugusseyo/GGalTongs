using System.Collections.Generic;
using UnityEngine;

public class SetCard : MonoBehaviour
{
    [SerializeField] GameObject skillCard;
    [SerializeField] GameObject StatCard_1;
    [SerializeField] GameObject StatCard_2;

    [SerializeField] SkillCardSO[] _skills;

    [SerializeField] StatCardSO[] _stats;

    private SkillCardSO _selectedSkill;
    private StatCardSO _selectedStat_1;
    private StatCardSO _selectedStat_2;

    private List<SkillCardSO> _skillDictionary = new List<SkillCardSO>();
    private List<StatCardSO> _StatDictionary = new List<StatCardSO>();
    private void CardSetting()
    {
        ChooseCard();


    }

    private void ChooseCard()
    {
        _selectedSkill = _skillDictionary[Random.Range(0, _skillDictionary.Count)];
        _selectedStat_1 = _StatDictionary[Random.Range(0, _StatDictionary.Count)];
        do
        {
            StatCardSO _selectedStat_2 = _StatDictionary[Random.Range(0, _StatDictionary.Count)];
        }
        while (_selectedStat_2 != _selectedStat_1);
    }
}
