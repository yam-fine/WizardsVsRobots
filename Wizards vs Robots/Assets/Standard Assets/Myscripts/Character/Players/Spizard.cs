using UnityEngine;

public class Spizard : Player {

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject basicBullet;
    RaycastHit hit;
    int rayDistance;

    public override void BasicAttack()
    {
        crosshair.CrosshairBig();

        // get direction
        Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, 500, 9);

        GameObject bullet = Instantiate(basicBullet);
        bullet.transform.position = firePoint.transform.position;
        bullet.GetComponent<SwordCollider>().Damage = Damage;

        // determine hit point
        if (hit.transform != null)
            bullet.transform.LookAt(hit.point);
        else
        {
            Vector3 point = myCamera.transform.position + myCamera.transform.forward * 55;
            Debug.Log(myCamera.transform.forward);
            bullet.transform.LookAt(point);
        }
    }

    public override void MobilityAttack()
    {
        crosshair.CrosshairSmall();
    }
}
