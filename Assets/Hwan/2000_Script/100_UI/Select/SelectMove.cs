using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectMove : MonoBehaviour
{
    [SerializeField] private bool _isNotS = true;

    private RectTransform _rectT;

    [SerializeField] private float _stopTargetY = 0f;

    private Button button;

    [SerializeField] private  int _speed;
    [SerializeField] private float _interval;

    private Coroutine stopCo;

    [SerializeField] private CardSetter _cardSetter;
    [SerializeField] private RectMask2D _rectMask;

    [SerializeField] private CardMoveMode _mode = CardMoveMode.Stoped;
    private void Awake()
    {
        _cardSetter = GameObject.Find("SkillOut").GetComponent<CardSetter>();
        _rectMask = _cardSetter.transform.GetComponentInChildren<RectMask2D>();

        _rectT = GetComponent<RectTransform>();

        if ( _isNotS)
        {
            button = GetComponent<Button>();
        }
    }

    public void ChangeMode(int value)
    {
        _mode = (CardMoveMode)value;
        if (_mode == CardMoveMode.Stoped)
        {
            StopMethod();
        }
    }

    public void ChangeMode()
    {
        _mode++;
        if (_mode == CardMoveMode.Stoped)
        {
            StopMethod();
        }
    }
    private void StopMethod()
    {
        if (_isNotS) button.interactable = true;
        else
        {
            _cardSetter.SetCard(GetComponent<CardSetter>()._nowSkill);
            _cardSetter.GetComponent<Button>().interactable = true;
            _rectMask.enabled = false;
        }
    }


    private void Update()
    {
        switch (_mode)
        {
            case CardMoveMode.Stoped:
                _rectT.anchoredPosition = new Vector2(_rectT.anchoredPosition.x, _stopTargetY);
                break;
            case CardMoveMode.Pulled:
                if (stopCo == null)
                {
                    stopCo = StartCoroutine(StopCo());
                }
                if (_isNotS) button.interactable = false;
                else
                {
                    _cardSetter.GetComponent<Button>().interactable = false;
                    _rectMask.enabled = true;
                }
                _rectT.anchoredPosition -= new Vector2(0, _speed) * Time.unscaledDeltaTime;
                break;
        }

        WarpCheck();
    }

    private IEnumerator StopCo()
    {
        yield return new WaitForSecondsRealtime(_interval);
        ChangeMode(0);
        stopCo = null;
    }

    private void WarpCheck()
    {
        if (_rectT.anchoredPosition.y <= -1080)
        {
            _rectT.anchoredPosition = new Vector2(_rectT.anchoredPosition.x, 1080);
        }
    }

}
