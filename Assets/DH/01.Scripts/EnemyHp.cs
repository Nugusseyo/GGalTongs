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


    public float xpOnDeath = 30f;


    public ExperienceBarController xpBar;

    void Awake()
    {
        CurrentHp = MaxHp;
    }

    void Start()
    {
        if (xpBar == null)
        {
            xpBar = FindObjectOfType<ExperienceBarController>();
            if (xpBar == null)
            {

            }
        }
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
        if (xpBar != null)
        {
            xpBar.AddXP(xpOnDeath);
        }

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