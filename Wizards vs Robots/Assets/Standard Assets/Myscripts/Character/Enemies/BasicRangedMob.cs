﻿using UnityEngine;

public class BasicRangedMob : Enemy
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform firePoint;

    public override void Attack()
    {
        if (CanAttack)
        {
            GameObject bullet = Instantiate(projectile);
            bullet.transform.position = firePoint.transform.position;
            bullet.GetComponent<SwordCollider>().Damage = Damage;
            bullet.transform.LookAt(target.transform);
        }

        base.Attack();
    }
}