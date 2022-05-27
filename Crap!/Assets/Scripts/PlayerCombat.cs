using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    KeyCode keyCode = KeyCode.F;

    public Transform attackPoint;
    public float radius = 1f;
    public LayerMask enemyLayer;

    [SerializeField] int damage = 20;

    [Tooltip("The player can attack [attackRate] amounts each second.")]
    [SerializeField] float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if(Input.GetKeyDown(keyCode))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        //Play attack animation (will be done later on)

        //Detect enemies in the range of the attack
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, radius, enemyLayer);

        //Apply damage
        foreach(Collider enemy in colliders)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
