using UnityEngine;

[RequireComponent(typeof(SwordCollider))]
public class HomingBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool destroyOnHit = true;
    [SerializeField] GameObject onHitFX;

    [HideInInspector] public Transform Target;
    
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distThisFrame, Space.World);
    }

    void HitTarget(Collision col)
    {
        if (onHitFX != null)
        {
            ContactPoint con = col.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, con.normal);
            Vector3 pos = con.point;
            GameObject hitEffect = Instantiate(onHitFX, pos, rot);
        }

        if (destroyOnHit)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitTarget(collision);
    }
}