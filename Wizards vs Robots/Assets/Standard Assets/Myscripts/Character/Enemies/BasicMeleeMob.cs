using UnityEngine;

public class BasicMeleeMob : Enemy
{
    SwordCollider swordCol;
    [SerializeField] Collider col;

    public override void Awake()
    {
        base.Awake();
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
        swordCol.Damage = Damage;
        MyAnimator.SetTrigger("Attack");

        base.Attack();
    }

    public override void BetweenAttacks()
    {
        
    }
}