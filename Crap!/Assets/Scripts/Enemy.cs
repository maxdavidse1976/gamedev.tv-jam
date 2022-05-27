using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform attackPoint;
    public float radius = 0.5f;
    public LayerMask playerLayer;

    [SerializeField] int damage = 20;

    [SerializeField] float attackRate = 1f;
    private float nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                EnemyAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void EnemyAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, radius, playerLayer);

        foreach (Collider player in colliders)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
