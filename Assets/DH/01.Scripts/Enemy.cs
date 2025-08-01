using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float attackCooldown = 1.0f;

    private Transform player;
    private bool Attacking = false;

    void Start()
    {
        GameObject yunkyu = GameObject.FindWithTag("Player");
        if (yunkyu != null)
            player = yunkyu.transform;
    }	

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > attackRange)
        {
            
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (!Attacking)
                StartCoroutine(DoAttack());
        }
    }

    private System.Collections.IEnumerator DoAttack()
    {
        Attacking = true;

        // 원하는 만큼 초를 센다 (예: 공격 준비 시간)
        yield return new WaitForSeconds(0.5f); // 이 값 조절 가능

        // 데미지 넣기 (UI 싱글톤 바로 호출)
        if (HealthBarUI.Instance != null)
        {
            HealthBarUI.Instance.PlayerDamaged(damage);
        }

        // 공격 후 쿨다운
        yield return new WaitForSeconds(attackCooldown);

        Attacking = false; 
    }
}