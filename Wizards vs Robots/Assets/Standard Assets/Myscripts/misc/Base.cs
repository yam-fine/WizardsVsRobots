using UnityEngine;

public class Base : Characters
{

    [SerializeField] Stat healthBar;

    public override bool IsDead => healthBar.CurrentValue <= 0;

    private void Start()
    {
        healthBar.Initialize();
    }

    public override void TakeDamage(Collider source)
    {
        if (takeDamageSourcesTags.Contains(source.tag))
        {
            healthBar.CurrentValue -= source.GetComponent<SwordCollider>().Damage;
            Debug.Log("base under fire " + source.GetComponent<SwordCollider>().Damage);
        }
    }
}