using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Characters {

    protected NavMeshAgent agent;
    protected GameObject target;
    protected GameManager gm;
    private EnemySight sight;

    [SerializeField] protected int money;
    [SerializeField] protected int health;
    public int Health { get { return health; } set { Mathf.RoundToInt(value); } }
    public GameObject Target {
        get { return target; }
        set { if (target != value) { target = value; Move(target.transform.position); } } }
    public int Money { get => money; set => money = value; }
    public override bool IsDead
    {
        get
        {
            return health <= 0;
        }
    }
    public EnemySight Sight { get => sight; set => sight = value; }

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        Sight = GetComponentInChildren<EnemySight>();
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
            gm.Coins = money;
            //gameObject.GetComponent<SpawnAI>().Remove();
            MyAnimator.SetBool("Dead", true);
            agent.isStopped = true;
        }
    }
    private protected void Move(Vector3 dest)
    {
        agent.SetDestination(dest);
    }

    public abstract void Attack();
}
