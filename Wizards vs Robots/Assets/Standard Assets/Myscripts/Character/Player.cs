using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public delegate void UpdateFPC();

public class Player : Characters {

    [SerializeField] Stat healthBar;
    FirstPersonController FPC;

    //public BarHandler HealthBar { get { return healthBar.Bar; } set { healthBar.Bar = value; } }
    public event UpdateFPC updateSpeed;
    public float Speed { get { return speed; } set { speed = value; updateSpeed(); } }

    private void Start()
    {
        FPC = GetComponent<FirstPersonController>();
        updateSpeed += () => FPC.m_WalkSpeed = Speed;
    }

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
