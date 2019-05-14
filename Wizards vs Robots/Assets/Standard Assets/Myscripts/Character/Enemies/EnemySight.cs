using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    //GameObject target;
    List<GameObject> inSight;

    public List<GameObject> InSight { get => inSight; set => inSight = value; }

    private void Start()
    {
        //target = GetComponentInParent<Enemy>().Target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Base")
        {
            inSight.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Base")
        {
            inSight.Remove(other.gameObject);
        }
    }
}