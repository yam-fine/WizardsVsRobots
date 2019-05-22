using UnityEngine;

public class BasicTurret : Turret
{


    public override void Attack()
    {
        base.Attack();

        GameObject bullet = Instantiate(projectile);
        bullet.GetComponent<HomingBullet>().Target = target;
        bullet.GetComponent<SwordCollider>().Damage = damage;
        bullet.transform.position = firePos.position;
    }
}