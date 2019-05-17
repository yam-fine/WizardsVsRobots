using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : Characters {

    protected NavMeshAgent agent;
    protected GameObject target;
    protected GameManager gm;
    //private bool canAttack = true;
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
    //public bool CanAttack
    //{
    //    get => canAttack;
    //    set
    //    {
    //        canAttack = value;

    //        //if (!value)
    //        //    StartCoroutine(ResetAttack());
    //    }
    //}

    public virtual void Start()
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
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    public virtual void Attack()
    {
        //CanAttack = false;
        agent.isStopped = true;
    }

    //IEnumerator ResetAttack()
    //{
    //    yield return new WaitForSeconds(attackSpeed);

    //    canAttack = true;
    //}

    private void Update()
    {
        Debug.Log(target);
    }
}
