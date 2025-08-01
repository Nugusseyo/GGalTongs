using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{

    private Button button;
    [SerializeField] private CardSetter _setter;

    [SerializeField] int waitTime = 2;

    [SerializeField] private bool _isNotS;

    private void Awake()
    {
        button = GetComponent<Button>();
        _setter = GetComponent<CardSetter>();

        button.onClick.AddListener(() => _setter.Use());
        if (_isNotS)
        {
            button.onClick.AddListener(() => _setter.Refresh());
        }
        button.onClick.AddListener(() => StartCoroutine(Close()));
        button.onClick.AddListener(() => FindAnyObjectByType<SetCard>().ButtonInter(false));
    }

    private IEnumerator Close()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        SelectManager.Instance.CloseUI();
    }
}
