using UnityEngine;

public class Enemy : Characters  {

    [SerializeField] int health;
    public int Health { get { return health; } set { Mathf.RoundToInt(value); } }

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }

    public override void Death()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(Collider source)
    {
        int dmg;

        if (source.tag == "PlayerDmgSource")
        {
            dmg = Mathf.RoundToInt(source.GetComponent<SwordCollider>().Damage);
        }
        else
        {
            dmg = 0;
            Debug.Log("DmgSource holds no damage");
        }

        health -= dmg;
        Debug.Log("Ouch");

        if (!IsDead)
        {
            //MyAnimator.SetBool("TakeDmg", true);
        }
        else
        {
            //score.CountScore = points;
            //gameObject.GetComponent<SpawnAI>().Remove();
            //MyAnimator.SetTrigger("Dead");
        }
    }
}
