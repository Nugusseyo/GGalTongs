using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetCard : MonoBehaviour
{
    [Header("Ä«µå ÇÁ¸®ÆÕ")]
    [SerializeField] private GameObject _skillCard_Prefab;
    [SerializeField] private GameObject _statCard_1_Prefab;
    [SerializeField] private GameObject _statCard_2_Prefab;

    [Header("½ºÅ³ SOµé")]
    [SerializeField] private SkillSO[] _skills;

    [Header("½ºÅÈ SOµé")]
    [SerializeField] private StatCardSO[] _stats;

    public Dictionary<int, CardSetter> CardDictionary { get; private set; } = new Dictionary<int, CardSetter>();

    public void Awake()
    {
        MakeCard();
        ChooseCard();
        MoveCard();

        gameObject.SetActive(false);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChooseCard();
        }
    }
    public void ChooseCard()
    {
        Debug.Log("¹Ù²ñ");
        for (int i = 1; i <= 3; i++)
        {
            int s2 = 0;
            int s3 = 1;

            CardDictionary[1 + ((i - 1) * 3)].SetCard(_skills[Random.Range(0, _skills.Length)]);

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
        for (int i = 1; i <= 3; i++)
        {
            GetComponent<MoveStarter>().MoveStart += CardDictionary[i].GetComponent<SelectMove>().StartMove;
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

    public void AnimatorInter(bool boo)
    {
        for (int i = 1; i <= 3; i++)
        {
            CardDictionary[i].GetComponent<Button>().interactable = boo;
        }
    }
    private void OnEnable()
    {
        ChooseCard();
    }
}
