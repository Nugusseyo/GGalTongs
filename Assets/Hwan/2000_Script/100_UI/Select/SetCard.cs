using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private RectTransform _range;

    private Button _outButton;
    [SerializeField] private ClickManager _clickM;
    public void Awake()
    {
        _outButton = GameObject.Find("SkillOut").GetComponent<Button>();

        foreach (StatCardSO SO in _stats)
        {
            SO.First();
        }

        MakeCard();
        ChooseCard();
        MoveCard();

        gameObject.SetActive(false);

    }

    private void MakeCard()
    {
        CardDictionary.Add(1, Instantiate(_skillCard_Prefab, _range).GetComponent<CardSetter>());
        CardDictionary.Add(2, Instantiate(_statCard_1_Prefab, transform).GetComponent<CardSetter>());
        CardDictionary.Add(3, Instantiate(_statCard_2_Prefab, transform).GetComponent<CardSetter>());

        CardDictionary.Add(4, Instantiate(_skillCard_Prefab, CardDictionary[1].transform).GetComponent<CardSetter>());
        CardDictionary.Add(5, Instantiate(_statCard_1_Prefab, CardDictionary[2].transform).GetComponent<CardSetter>());
        CardDictionary.Add(6, Instantiate(_statCard_2_Prefab, CardDictionary[3].transform).GetComponent<CardSetter>());

        CardDictionary.Add(7, Instantiate(_skillCard_Prefab, CardDictionary[1].transform).GetComponent<CardSetter>());
        CardDictionary.Add(8, Instantiate(_statCard_1_Prefab, CardDictionary[2].transform).GetComponent<CardSetter>());
        CardDictionary.Add(9, Instantiate(_statCard_2_Prefab, CardDictionary[3].transform).GetComponent<CardSetter>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChooseCard();
        }
    }
    public void ChooseCard()
    {
        bool maxSkill = true;
        for (int i = 0; i < _skills.Length; i++)
        {
            if (_skills[i].CurrentLevel < _skills[i].LevelLimit)
            {
                maxSkill = false;
                break;
            }
        }
        _clickM.CanGet = !maxSkill;

        for (int i = 1; i <= 3; i++)
        {
            int s1;
            int s2 = 0;
            int s3 = 1;

            if (!maxSkill)
            {
                do
                {
                    s1 = Random.Range(0, _skills.Length);
                }
                while (_skills[s1].CurrentLevel >= _skills[s1].LevelLimit);
            }
            else
            {
                s1 = Random.Range(0, _skills.Length);
            }

            CardDictionary[1 + ((i - 1) * 3)].SetCard(_skills[s1]);

            s2 = Random.Range(0, _stats.Length);
            CardDictionary[2 + ((i - 1) * 3)].SetCard(_stats[s2]);
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
        _outButton.GetComponent<CardSetter>().ChildCardSetter = CardDictionary[1];

        for (int i = 1; i <= 3; i++)
        {
            GetComponent<MoveStarter>().MoveStart += CardDictionary[i].GetComponent<SelectMove>().ChangeMode;
            CardDictionary[i].GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        }


        for (int i = 4; i <= CardDictionary.Count; i++)
        {
            CardDictionary[i].GetComponent<RectTransform>().localScale = Vector3.one;
            Destroy(CardDictionary[i].GetComponent<SelectMove>());
        }
        CardDictionary[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);
        CardDictionary[5].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);
        CardDictionary[6].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);

        CardDictionary[7].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
        CardDictionary[8].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
        CardDictionary[9].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1080);
    }

    public void ButtonInter(bool boo)
    {
        _outButton.interactable = boo;
        for (int i = 2; i <= 3; i++)
        {
            CardDictionary[i].GetComponent<Button>().interactable = boo;
        }
    }
    private void OnEnable()
    {
        ChooseCard();
    }
}
