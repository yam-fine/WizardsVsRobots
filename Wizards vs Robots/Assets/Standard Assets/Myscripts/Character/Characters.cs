using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Characters : MonoBehaviour {

    [SerializeField] protected float attackSpeed = 1;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected List<string> takeDamageSourcesTags;
    protected bool Attack;

    public Animator MyAnimator { get; private set; }
    public Rigidbody MyRigidbody { get; private set; }
    public abstract void TakeDamage(Collider source);
    public abstract bool IsDead { get; }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }
    public virtual float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public abstract void Death();

    public virtual void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        MyRigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (takeDamageSourcesTags.Contains(other.tag))
        {
            TakeDamage(other);
        }
    }
}
