
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject impactEffect;

    private Transform target;

    public float speed = 70f;

    public int damage = 50;

    public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effecrtIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effecrtIns, 2f);

        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    void Damage(Transform enemy)
    {
        Enemies e = enemy.GetComponent<Enemies>();

        if(e == null)
        {
            Debug.LogError("Attention! Il n'y a pas de script sur l'enemmi !");

            return;
        }
        else
        {
            e.TakeDammage(damage);
        }

    }

}
