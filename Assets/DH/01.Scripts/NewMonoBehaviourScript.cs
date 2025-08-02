using UnityEngine;

public class NewMonoBehaviorScript : MonoBehaviour
{
    [SerializeField] private float maxHp = 20f;
    public float CurrentHp { get; private set; }
    public float MaxHp => maxHp;

    public float HealthFraction
    {
        get
        {
            if (MaxHp <= 0f) return 0f;
            return CurrentHp / MaxHp;
        }
    }

    [Header("XP")]
    [SerializeField] private float xpValue = 0.2f; // 경험치 바 기준, 1.0이 한 레벨이면 20% 채우는 값

    void Awake()
    {
        CurrentHp = MaxHp;
    }

    public void TakeDamage(float amount)
    {
        CurrentHp = Mathf.Clamp(CurrentHp - amount, 0f, MaxHp);

        if (CurrentHp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // 죽으면 경험치 주기
        FillBarContoller.Instance?.AddXP(xpValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(GunFire.Instance.AttackPower);
            Destroy(other.gameObject);
        }
    }
}

