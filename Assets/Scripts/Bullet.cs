
using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private GameObject enemy;
    public float speed = 70f;
    public GameObject impactEffect;
    public float damage = 0f;
    private Vector2 direction;
    public void Seek(Transform _target, GameObject en, float _damage)
    {
        enemy = en;
        target = _target;
        damage = _damage;
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
        other.TakeDamage(dmg);
    }

        private void HitTarget()
    {
        //Debug.Log("Hit");
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        //Destroy(target.gameObject);
        RegisterHit(damage);
        Destroy(gameObject);//destroy bullet
    }
}
