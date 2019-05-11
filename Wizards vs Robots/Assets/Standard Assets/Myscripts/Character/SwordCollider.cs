using UnityEngine;

public class SwordCollider : MonoBehaviour  {

    float damage;

    public float Damage
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
}
