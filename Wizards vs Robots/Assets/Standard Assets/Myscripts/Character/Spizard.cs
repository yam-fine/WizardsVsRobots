using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spizard : Player {

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject basicBullet;

    public override void BasicAttack()
    {
        crosshair.CrosshairBig();

        GameObject bullet = Instantiate(basicBullet);
        bullet.transform.position = firePoint.transform.position;
        bullet.transform.forward = myCamera.transform.forward;
    }

    public override void MobilityAttack()
    {
        crosshair.CrosshairSmall();
    }
}
