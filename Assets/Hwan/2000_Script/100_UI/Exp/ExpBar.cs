using UnityEngine;
using UnityEngine.InputSystem;

public class ExpBar : MonoBehaviour
{
    private float scale;
    public RectTransform hpBar;
    public float maxHealth = 25;
    private float curHealth;
    private Vector2 barSize;

    private void Awake()
    {
        curHealth = maxHealth;
        barSize = hpBar.sizeDelta;
        barSize.x = (100 / maxHealth) * 5 - (float)0.7;
        hpBar.sizeDelta = barSize;
        UpdateHealthBar(maxHealth);
    }
    public void UpdateHealthBar(float health)
    {
        scale = Mathf.Clamp(health * 1, 0, maxHealth);
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            curHealth--;
            UpdateHealthBar(curHealth);
            Debug.Log(curHealth);
        }
        hpBar.localScale = Vector2.Lerp(hpBar.localScale, new Vector2(scale, hpBar.localScale.y), Time.deltaTime * 8);
    }
}
