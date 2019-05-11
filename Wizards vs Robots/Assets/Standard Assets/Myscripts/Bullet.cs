using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float lifeTime = 1;
    [SerializeField] GameObject onHitFX;
    [SerializeField] bool destroyOnHit = false;
    Rigidbody myRigidbody;
    Vector2 direction;

    public float Speed { get { return speed; } }
    public float LifeTime { get { return lifeTime; } }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        StartCoroutine(KillMyself());
    }

    //public void Initialize(float speed)
    //{
    //    this.speed *= speed;
    //}

    IEnumerator KillMyself ()
    {
        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (onHitFX != null)
        {
            ContactPoint con = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, con.normal);
            Vector3 pos = con.point;
            
            GameObject hitEffect = Instantiate(onHitFX, pos, rot);
        }

        if (destroyOnHit)
            gameObject.SetActive(false);
    }
}