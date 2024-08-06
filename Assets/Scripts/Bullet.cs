
using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    public GameObject impactEffect;
    public float damage = 0f;
    [SerializeField]
    private float effectsDuration = 1.0f;

    private Transform target;
    private GameObject enemy;
    private int exGoldKill = 0;
    private float slowPct = 0;
    /**
     *  -- sets needed variables for correct functioning.
     */
    public void Seek(Transform _target, GameObject en, float _damage, int extraGoldPerKill, float _slowPct)
    {
        enemy = en;
        target = _target;
        damage = _damage;
        exGoldKill = extraGoldPerKill;
        slowPct = _slowPct;
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

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    private void RegisterHit(float dmg)
    {
        //enemy take damage
        GameObject go = enemy;
        Enemy other = (Enemy)go.GetComponent(typeof(Enemy));
        other.TakeDamage(dmg, exGoldKill, slowPct);
    }

    private void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, effectsDuration);
        RegisterHit(damage);
        Destroy(gameObject);//destroy bullet
    }
}
