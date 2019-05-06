using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float lifeTime = 1;
    Rigidbody myRigidbody;
    Vector2 direction;

    float damage { get; set; }

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

    public void Initialize(Vector2 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }

    IEnumerator KillMyself ()
    {
        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }
}