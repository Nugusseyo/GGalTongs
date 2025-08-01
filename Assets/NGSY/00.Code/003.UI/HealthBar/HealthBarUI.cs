using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HealthBarUI : MonoBehaviour
{
    public static HealthBarUI Instance;

    [SerializeField] private GunFireAudioClip audioPlayer;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private RectTransform hpBar;
    private GunFireCameraShaker _cameraShaker;

    public float MaxHealth { get; private set; }
    private float _curHealth;
    private float _maxBarWidth;
    private float _targetRatio = 1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        MaxHealth = 25;
        _curHealth = MaxHealth;
        _maxBarWidth = hpBar.sizeDelta.x;
        UpdateHealthBar(_curHealth);
    }

    private void Start()
    {
        _cameraShaker = GameObject.Find("Player").GetComponentInChildren<GunFireCameraShaker>();
    }

    private void UpdateHealthBar(float health)
    {
        _targetRatio = Mathf.Clamp01(health / MaxHealth);
        healthText.text = $"{(int)_curHealth} / {(int)MaxHealth}";
    }

    public void PlusMaxHealth(float value)
    {
        MaxHealth += value;
        _curHealth += value;
        UpdateHealthBar(_curHealth);
    }

    public void PlayerDamaged(float amount)
    {
        _curHealth = Mathf.Clamp(_curHealth - amount, 0, MaxHealth);
        UpdateHealthBar(_curHealth);
        _cameraShaker.ShakeCamera();
        audioPlayer.PlayShotSound();
    }

    public void PlusCurrentHealth(float value)
    {
        _curHealth = Mathf.Clamp(_curHealth + value, 0, MaxHealth);
        UpdateHealthBar(_curHealth);
    }

    private void Update()
    {
        float currentWidth = hpBar.sizeDelta.x;
        float targetWidth = _maxBarWidth * _targetRatio;

        float smoothedWidth = Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * 10f); // 속도는 조절 가능

        Vector2 newSize = hpBar.sizeDelta;
        newSize.x = smoothedWidth;
        hpBar.sizeDelta = newSize;
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            PlusMaxHealth(6);
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            PlayerDamaged(3);
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            PlusCurrentHealth(5);
        }
    }
}
