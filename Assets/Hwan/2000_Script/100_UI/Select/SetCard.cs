using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCard : MonoBehaviour
{
    [Header("ī�� ������")]
    [SerializeField] GameObject skillCard;
    [SerializeField] GameObject statCard_1;
    [SerializeField] GameObject statCard_2;

    [Header("��ų SO��")]
    [SerializeField] SkillCardSO[] _skills;

    [Header("���� SO��")]
    [SerializeField] StatCardSO[] _stats;

    private List<SkillCardSO> _skillDictionary = new List<SkillCardSO>();
    private List<StatCardSO> _StatDictionary = new List<StatCardSO>();
    private void CardSetting()
    {
        ChooseCard();
    }

    private void ChooseCard()
    {
        SkillCardSO _selectedSkill;
        StatCardSO _selectedStat_1;
        StatCardSO _selectedStat_2;

        _selectedSkill = _skillDictionary[Random.Range(0, _skillDictionary.Count)];
        _selectedStat_1 = _StatDictionary[Random.Range(0, _StatDictionary.Count)];
        do
        {
            _selectedStat_2 = _StatDictionary[Random.Range(0, _StatDictionary.Count)];
        }
        while (_selectedStat_2 != _selectedStat_1);
    }
}
