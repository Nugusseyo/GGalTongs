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

    private AudioSource _audio;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        _audio = GameObject.Find("Background").GetComponent<AudioSource>();

        button = GetComponent<Button>();
        _setter = GetComponent<CardSetter>();

        button.onClick.AddListener(() => {
            if (CanGet) StartCoroutine(Close());
        });
    }

    private IEnumerator Close()
    {
        _audio.PlayOneShot(_clip);
        _setter.Use();
        if (_isNotS)
        {
            _setter.Refresh();
        }
        FindAnyObjectByType<SetCard>().ButtonInter(false);
        yield return new WaitForSecondsRealtime(waitTime);
        SelectManager.Instance.CloseUI();
    }
}
