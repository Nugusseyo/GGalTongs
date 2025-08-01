using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class SelectMove : MonoBehaviour
{
    private RectTransform _rectT;

    [SerializeField] private float _stopTargetY = 0f;

    private Button button;

    [SerializeField] private  int _speed;
    [SerializeField] private float _interval;

    private Coroutine stopCo;

    private void Awake()
    {
        _rectT = GetComponent<RectTransform>();

        button = GetComponent<Button>();
    }

    public void ChangeMode(int value)
    {
        _mode = (CardMoveMode)value;
        if (_mode == CardMoveMode.Stoped)
        {
            button.interactable = true;
        }
    }
    public void ChangeMode()
    {
        _mode++;
        if (_mode == CardMoveMode.Stoped)
        {
            button.interactable = true;
        }
    }

    [SerializeField] private CardMoveMode _mode = CardMoveMode.Stoped;

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
                button.interactable = false;
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
