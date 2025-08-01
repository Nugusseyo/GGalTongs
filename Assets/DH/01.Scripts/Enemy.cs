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


        yield return new WaitForSeconds(0.5f);


        if (HealthBarUI.Instance != null)
        {
            HealthBarUI.Instance.PlayerDamaged(damage);
        }


        yield return new WaitForSeconds(attackCooldown);

        Attacking = false; 
    }
    
}