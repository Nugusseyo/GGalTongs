using UnityEngine;

public class SelectMove : MonoBehaviour
{
    private RectTransform _rectT;

    [SerializeField] private int _spinSpeed = 100;
    [SerializeField] private float _stopTime = 1.5f;       // 감속에 걸리는 시간
    [SerializeField] private int _stopValue = 1000;        // Y=0에서 멈추기 위한 최소 속도 기준
    [SerializeField] private int _slowValue = -500;        // Y=0에서 멈추기 위한 최소 속도 기준
    [SerializeField] private int _endSpeed = 1000;        // Y=0에서 멈추기 위한 최소 속도 기준
    [SerializeField] private int _startEndSpeed = 1000;        // Y=0에서 멈추기 위한 최소 속도 기준

    private float _nowSpeed;
    private float _currentStopTime = 0f;

    private bool _moving = false;
    private bool _canMove = false;
    private bool _stoping = false;
    private bool _ending = false;

    private float _nowYValue;
    private int _moveDir = 1;

    private void Awake()
    {
        _rectT = GetComponent<RectTransform>();
    }

    public void MoveStart()
    {
        _nowSpeed = _spinSpeed;
        _canMove = true;
        _moving = true;
        _stoping = false;
        _ending = false;
        _currentStopTime = 0f;
        _moveDir = 1;
    }

    void Update()
    {
        if (_canMove)
        {
            // 움직이기
            _rectT.anchoredPosition -= new Vector2(0, _nowSpeed) * Time.deltaTime * _moveDir;

            // 감속 중이면 속도 줄이기
            if (_stoping)
            {
                _currentStopTime += Time.deltaTime;
                float t = Mathf.Clamp01(_currentStopTime / _stopTime);
                _nowSpeed = Mathf.Lerp(_spinSpeed, _slowValue, t); // 최소 속도 10까지 감속

                if (_nowSpeed <= _stopValue)
                {
                    _ending = true;
                    _stoping = false;
                    _nowYValue = _rectT.anchoredPosition.y;
                    _moveDir = (int)(_rectT.anchoredPosition.y / Mathf.Abs(_rectT.anchoredPosition.y));
                }
            }

            if (_ending)
            {
                float t = 1 - Mathf.Clamp01(Mathf.Abs(_rectT.anchoredPosition.y) / Mathf.Abs(_nowYValue));
                _nowSpeed = Mathf.Lerp(_endSpeed / 6f, _endSpeed, t);
            }

            if (_ending && Mathf.Clamp01(Mathf.Abs(_rectT.anchoredPosition.y) / Mathf.Abs(_nowYValue)) <= 0.2f)
            {
                _rectT.anchoredPosition = new Vector2(_rectT.anchoredPosition.x, 0);
                _canMove = false;
                _moving = false;
                _ending = false;
            }
        }

        // 입력 처리
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_moving)
            {
                MoveStart();
            }
            else
            {
                _stoping = true;
            }
        }

        WarpCheck();
    }

    private void WarpCheck()
    {
        if (_rectT.anchoredPosition.y <= -1080)
        {
            _rectT.anchoredPosition = new Vector2(_rectT.anchoredPosition.x, 1080);
        }
    }
}
