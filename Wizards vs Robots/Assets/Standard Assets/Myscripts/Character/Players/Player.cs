using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public delegate void UpdateFPC();

public abstract class Player : Characters {

    [SerializeField] protected CrossHair crosshair;
    [SerializeField] protected Stat healthBar;

    [SerializeField] protected float basicFireRate;
    [SerializeField] protected float mobilityFireRate;
    float currentBasicFireRate, currentMobilityFireRate;

    FirstPersonController FPC;
    protected Camera myCamera;
    bool canBasicAttack = true;
    bool canMobilityAttack = true;

    public event UpdateFPC updateSpeed;
    public override float Speed { get { return speed; } set { speed = value; updateSpeed(); } }
    
    //public float AttackSpeed { get { return AttackSpeed; }
    //                           set { attackSpeed += value;
    //                                 currentBasicFireRate = attackSpeed * basicFireRate;
    //                                 currentMobilityFireRate = attackSpeed * mobilityFireRate;
    //} }

    public virtual void Start()
    {
        FPC = GetComponent<FirstPersonController>();
        updateSpeed += () => FPC.m_WalkSpeed = Speed;
        healthBar.Initialize();
        myCamera = Camera.main;
    }

    public virtual void Update()
    {
        if (Input.GetMouseButton(0) && canBasicAttack)
        {
            BasicAttack();
            StartCoroutine(ResetAttack(1, basicFireRate));
        }

        if (Input.GetButtonUp("Jump") && canMobilityAttack)
        {
            MobilityAttack();
            StartCoroutine(ResetAttack(2, mobilityFireRate));
        }
    }

    IEnumerator ResetAttack(int sw, float time)
    {
        switch (sw)
        {
            case 1:
                canBasicAttack = false;
                break;
            case 2:
                canMobilityAttack = false;
                break;
        }

        yield return new WaitForSeconds(time);

        switch (sw)
        {
            case 1:
                canBasicAttack = true;
                break;
            case 2:
                canMobilityAttack = true;
                break;
        }
    }

    public abstract void BasicAttack();
    public abstract void MobilityAttack();

    public override bool IsDead
    {
        get { return healthBar.CurrentValue <= 0; }
    }

    public override void TakeDamage(GameObject source)
    {
        int dmg;
        dmg = Mathf.RoundToInt(source.GetComponent<SwordCollider>().Damage);

        healthBar.CurrentValue -= dmg;

        if (!IsDead)
            if (!Attacking)
                MyAnimator.SetBool("TakeDmg", true);
        //else
        //    if (Dead != null)
        //        Dead();
    }
}
