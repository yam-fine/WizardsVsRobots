using UnityEngine;

public class BasicMeleeMob : Enemy
{
    [SerializeField] Collider col;
    SwordCollider swordCol;

    public override void Start()
    {
        base.Start();
        swordCol = col.GetComponent<SwordCollider>();
    }

    public void StartAttack()
    {
        col.enabled = true;
    }

    public void StopAttack()
    {
        col.enabled = false;
    }

    public override void Attack()
    {
        agent.isStopped = true;
        swordCol.Damage = Damage;
        MyAnimator.SetTrigger("Attack");
    }
}