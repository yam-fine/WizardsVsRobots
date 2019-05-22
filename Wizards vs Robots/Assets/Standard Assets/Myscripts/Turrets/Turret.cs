using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    float attackCountdown;
    Transform startRot;

    protected Transform target = null;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected float radius;
    [SerializeField] protected Transform firePos;

    private void Start()
    {
        startRot = transform;
    }

    private void Update()
    {
        if (target == null || Vector3.Distance(transform.position, target.position) > radius || target.GetComponent<Enemy>().IsDead)
        {
            target = FindTarget();
        }

        if (target != null)
        {
            LookAt(target);
            if (attackCountdown <= 0)
            {
                Attack();
            }
        }
        else
            LookAt(startRot);

        if (attackCountdown > 0)
            attackCountdown -= Time.deltaTime;
    }

    public virtual void Attack()
    {
        attackCountdown = attackSpeed;
    }

    void LookAt(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    Transform FindTarget()
    {
        int layerMask = 1 << 10;
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (enemies.Length > 1)
        {
            Transform target = null;
            float nearestDist = float.MaxValue;

            foreach (Collider enemy in enemies)
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist < nearestDist)
                {
                    target = enemy.transform;
                    nearestDist = dist;
                }
            }

            return target;
        }
        else if (enemies.Length == 1)
        {
            return enemies[0].transform;
        }
        else
        {
            return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}