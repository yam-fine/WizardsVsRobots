using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Characters : MonoBehaviour {

    [SerializeField] protected int health { get { return health; } set { Mathf.RoundToInt(value); } }
    //[SerializeField] protected int armor { get { return armor; } set { Mathf.Clamp(armor, 1, value); } }
    [SerializeField] protected List<string> takeDamageSourcesTags;
    protected bool Attack;

    public int damage;
    public float speed;
    public Animator MyAnimator { get; private set; }
    public Rigidbody MyRigidbody { get; private set; }
    public abstract void TakeDamage(int damage);
    public abstract bool IsDead { get; }
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
            //TakeDamage();
        }
    }
}
