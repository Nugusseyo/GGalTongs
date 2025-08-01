using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    private Button button;
    private CardSetter setter;

    [SerializeField] int waitTime = 2;

    private void Awake()
    {
        button = GetComponent<Button>();
        setter = GetComponent<CardSetter>();

        button.onClick.AddListener(() => setter.Use());
        button.onClick.AddListener(() => StartCoroutine(Close()));
        button.onClick.AddListener(() => FindAnyObjectByType<SetCard>().ButtonInter(false));
    }

    private IEnumerator Close()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        SelectManager.Instance.CloseUI();
    }
}
