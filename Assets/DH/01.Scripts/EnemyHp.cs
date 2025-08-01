using UnityEngine;

public class EnemyHP : MonoBehaviour
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

    void Awake()
    {
        CurrentHp = MaxHp;
    }

    public void TakeDamage(float amount)
    {
        CurrentHp = Mathf.Clamp(CurrentHp - amount, 0f, MaxHp);
        Debug.Log($"남은 HP: {CurrentHp}/{MaxHp}");

        if (CurrentHp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1f);
            Destroy(other.gameObject);
        }
    }
}