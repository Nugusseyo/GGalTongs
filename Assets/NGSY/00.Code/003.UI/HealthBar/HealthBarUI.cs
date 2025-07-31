using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HealthBarUI : MonoBehaviour
{
    public static HealthBarUI Instance;

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private RectTransform hpBar;

    public float MaxHealth { get; private set; }
    private float curHealth;
    private float maxBarWidth;
    private float targetRatio = 1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        MaxHealth = 25;
        curHealth = MaxHealth;
        maxBarWidth = hpBar.sizeDelta.x;
        UpdateHealthBar(curHealth);
    }

    private void UpdateHealthBar(float health)
    {
        targetRatio = Mathf.Clamp01(health / MaxHealth);
        _healthText.text = $"{(int)curHealth} / {(int)MaxHealth}";
    }

    public void PlusMaxHealth(float value)
    {
        MaxHealth += value;
        curHealth += value;
        UpdateHealthBar(curHealth);
    }

    public void PlayerDamaged(float amount)
    {
        curHealth = Mathf.Clamp(curHealth - amount, 0, MaxHealth);
        UpdateHealthBar(curHealth);
    }

    public void PlusCurrentHealth(float value)
    {
        curHealth = Mathf.Clamp(curHealth + value, 0, MaxHealth);
        UpdateHealthBar(curHealth);
    }

    private void Update()
    {
        float currentWidth = hpBar.sizeDelta.x;
        float targetWidth = maxBarWidth * targetRatio;

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
