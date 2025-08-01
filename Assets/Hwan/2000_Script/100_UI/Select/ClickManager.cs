using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public bool CanGet = true;

    private Button button;
    [SerializeField] private CardSetter _setter;

    [SerializeField] int waitTime = 2;

    [SerializeField] private bool _isNotS;

    private void Awake()
    {
        button = GetComponent<Button>();
        _setter = GetComponent<CardSetter>();

        button.onClick.AddListener(() => {
            if (CanGet) StartCoroutine(Close());
        });
    }

    private IEnumerator Close()
    {
        button.onClick.AddListener(() => _setter.Use());
        if (_isNotS)
        {
            button.onClick.AddListener(() => _setter.Refresh());
        }
        FindAnyObjectByType<SetCard>().ButtonInter(false);
        yield return new WaitForSecondsRealtime(waitTime);
        SelectManager.Instance.CloseUI();
    }
}
