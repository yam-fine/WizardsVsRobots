using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public delegate void UpdateFPC();

public abstract class Player : Characters {

    [SerializeField] protected float basicFireRate;
    [SerializeField] protected float mobilityFireRate;
    [SerializeField] protected CrossHair crosshair;
    [SerializeField] protected Stat healthBar;
    FirstPersonController FPC;
    protected Camera myCamera;

    bool canBasicAttack = true;
    bool canMobilityAttack = true;

    //public BarHandler HealthBar { get { return healthBar.Bar; } set { healthBar.Bar = value; } }
    public event UpdateFPC updateSpeed;
    public float Speed { get { return speed; } set { speed = value; updateSpeed(); } }
    //public event TriggerAbility OnBasicAttack;
    //public event TriggerAbility OnMobilityAttack;

    private void Start()
    {
        FPC = GetComponent<FirstPersonController>();
        updateSpeed += () => FPC.m_WalkSpeed = Speed;
        healthBar.Initialize();
        myCamera = Camera.main;
    }

    private void Update()
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

    public override void Death()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage(int dmg)
    {
        healthBar.CurrentValue -= dmg;

        if (!IsDead)
            if (!Attack)
                MyAnimator.SetBool("TakeDmg", true);
        //else
        //    if (Dead != null)
        //        Dead();
    }
}
