using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float fireRate = 2f;
    private float fireCountdown = 0f;
    public float range = 3f;
    public float damage = 100f;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;
    private GameObject enemy;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearestEnemey = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemey = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemey < shortesDistance)
            {
                shortesDistance = distanceToEnemey;
                nearestEnemey = enemy;
            }
        }

        if(nearestEnemey != null && shortesDistance <= range) 
        {
            target = nearestEnemey.transform;

            enemy = nearestEnemey;
        }
        else
        {
            target = null;  
        }

    }
    void Update()
    {
        //if (target == null) { return; }


        if(fireCountdown <= 0f && target != null)
        {

            Vector3 dir = target.position - transform.position;//get destination from point A to point B
            Shoot();
            fireCountdown = 1f*fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    private void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target, enemy, damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
