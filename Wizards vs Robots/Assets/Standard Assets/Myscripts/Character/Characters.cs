using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Characters : MonoBehaviour {

    [SerializeField] protected float attackSpeed = 1;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected List<string> takeDamageSourcesTags;
    protected bool Attacking;

    public Animator MyAnimator { get; private set; }
    public Rigidbody MyRigidbody { get; private set; }
    public abstract void TakeDamage(GameObject source);
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

    public virtual void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        MyRigidbody = GetComponent<Rigidbody>();
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        if (takeDamageSourcesTags.Contains(other.gameObject.tag))
        {
            TakeDamage(other.gameObject);
        }
    }
}
