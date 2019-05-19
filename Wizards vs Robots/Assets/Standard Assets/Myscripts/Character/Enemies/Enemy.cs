using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : Characters {

    protected NavMeshAgent agent;
    protected GameObject target;
    GameObject lastTarget;
    protected GameManager gm;
    private EnemySight sight;

    [SerializeField] protected int money;
    [SerializeField] protected int health;
    public bool preferPlayer;
    public int Health { get { return health; } set { Mathf.RoundToInt(value); } }
    public GameObject Target {
        get { return target; }
        set { if (target != value) { target = value; } } }
    public int Money { get => money; set => money = value; }
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }
    public EnemySight Sight { get => sight; set => sight = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Sight = GetComponentInChildren<EnemySight>();
        target = Base.Instance.gameObject;
    }

    public override void TakeDamage(GameObject source)
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
            gm.Coins = money;
            //gameObject.GetComponent<SpawnAI>().Remove();
            MyAnimator.SetBool("Dead", true);
            agent.isStopped = true;
        }
    }
    public void Move()
    {
        if (lastTarget != Target)
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
            lastTarget = Target;
        }
    }

    public virtual void Attack()
    {
        agent.isStopped = true;
    }
}
