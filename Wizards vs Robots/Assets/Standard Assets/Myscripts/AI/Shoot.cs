using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Shoot")]
public class Shoot : Attack {

    [SerializeField] GameObject projectile;
    [SerializeField] int speed = 10;

    public override void Init()
    {
        return;
    }

    public override void TriggerAttack(Transform source)
    {
        GameObject shot = Instantiate(projectile,
                                      source.Find(string.Format("{0}_Pos", name)).transform.position,
                                      Quaternion.identity);
        //shot.GetComponent<SwordCollider>().Init(damage, source);
        if (source.rotation.y == 0)
        {
            //shot.GetComponent<Projectile>().Initialize(Vector2.right, speed);
        }
        else
        {
            //shot.GetComponent<Projectile>().Initialize(Vector2.left, speed);
            shot.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
