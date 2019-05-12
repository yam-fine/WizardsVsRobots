using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters {

    NavMeshAgent agent;
    GameObject target;

    [SerializeField] int health;
    public int Health { get { return health; } set { Mathf.RoundToInt(value); } }
    public GameObject Target {
        get { return target; }
        set { if (target != value) { target = value; Move(target.transform.position); } } }

    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
    private void Move(Vector3 dest)
    {
        agent.SetDestination(dest);
        Debug.Log("Hello there " + dest);
    }
}
