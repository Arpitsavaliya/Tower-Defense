using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float fireRate = 2f;
    private float fireCountdown = 0f;
    public float range = 3f;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

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
        }
        else
        {
            target = null;  
        }

    }
    void Update()
    {
        Debug.Log(fireCountdown);
        if (target == null) { return; }

        Vector3 dir = target.position - transform.position;//get destination from point A to point B

        if(fireCountdown <= 0f)
        {
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
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
