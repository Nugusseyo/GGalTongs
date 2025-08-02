using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private float maxHp = 20f;
    [SerializeField] private EnemyHealthBarUI healthBarPrefab;

    public float CurrentHp { get; private set; }
    public float MaxHp => maxHp;

    void Awake()
    {
        CurrentHp = MaxHp;
        
        healthBarPrefab.transform.SetParent(transform); 
        healthBarPrefab.SetFill(1f);
    }

    public void TakeDamage(float amount)
    {
        CurrentHp = Mathf.Clamp(CurrentHp - amount, 0f, MaxHp);

        if (healthBarPrefab != null)
            healthBarPrefab.SetFill(CurrentHp / MaxHp);

        if (CurrentHp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (healthBarPrefab != null)
            Destroy(healthBarPrefab.gameObject);

        if (ExpManager.Instance != null)
        {
            ExpManager.Instance.ExpUp((int)MaxHp / 10);
        }

        if(ScoreManager.Instance != null)
        {
        ScoreManager.Instance.killCount++;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(GunFire.Instance.AttackPower);
            PoolManager.Instance.Push(other.GetComponent<IPoolable>());
        }
    }
}