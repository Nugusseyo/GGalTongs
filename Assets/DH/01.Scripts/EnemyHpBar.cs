using UnityEngine;
using System.Collections;

public class EnemyHpBar : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float attackCooldown = 1.0f;

    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("XP")]
    public float xpValue = 0.2f; // 최대 경험치 바를 1.0이라 했을 때 20% 채우는 경험치

    private Transform _player;
    private bool _attacking = false;

    void Start()
    {
        currentHealth = maxHealth;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            _player = player.transform;
    }

    void Update()
    {
        if (_player == null) return;

        float dist = Vector3.Distance(transform.position, _player.position);
        if (dist > attackRange)
        {
            Vector3 dir = (_player.position - transform.position).normalized;
            transform.position += dir * (moveSpeed * Time.deltaTime);
        }
        else
        {
            if (!_attacking)
                StartCoroutine(DoAttack());
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private IEnumerator DoAttack()
    {
        _attacking = true;

        yield return new WaitForSeconds(0.5f);

        if (HealthBarUI.Instance != null)
        {
            HealthBarUI.Instance.PlayerDamaged(damage);
        }

        yield return new WaitForSeconds(attackCooldown);

        _attacking = false;
    }

    void Die()
    {
        // 적이 죽으면 경험치 주기
        FillBarContoller.Instance?.AddXP(xpValue);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            // 데미지 양은 실제 공격에서 전달하도록 리팩토링해도 됨
            TakeDamage(50f);
        }
    }
}