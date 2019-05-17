using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    //GameObject target;
    List<GameObject> inSight;
    Enemy myself;
    Base theBase;

    public List<GameObject> InSight { get => inSight; set => inSight = value; }

    private void Start()
    {
        myself = GetComponentInParent<Enemy>();
        theBase = Base.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Base")
        {
            inSight.Add(other.gameObject);

            if (myself.preferPlayer && other.tag == "Player")
                myself.Target = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Base")
        {
            inSight.Remove(other.gameObject);

            if (myself.preferPlayer && other.tag == "Player")
            {
                if (InSight.Count != 0)
                    myself.Target = InSight[0];
                else
                    myself.Target = theBase.gameObject;
            }
        }
    }
}