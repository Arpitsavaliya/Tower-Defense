using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    
    [Header("Attributes")]
    [SerializeField]
    [InspectorName("Turret Type")]
    private ScriptableTurret _t;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firePoint;

    // -- Private variables -- //
    private GameObject enemy;
    private TurretAnimation animController;
    private Transform target;
    private float fireCountdown = 0f;

    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }
    private void Awake()
    {
        animController = GetComponent<TurretAnimation>();
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

        if(nearestEnemey != null && shortesDistance <= _t.range) 
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
        if(fireCountdown <= 0f && target != null)
        {
            Shoot();
            fireCountdown = 1f*_t.fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (bulletGO.TryGetComponent<Bullet>(out var bullet))
        {
            // -- InitialDirection: -- //
            Vector2 direction = target.position - firePoint.position;
            // -- After getting the initial direction pointing towards the target, run directional animation: 
            if (animController != null)
            {
                animController.PlayShootingAnimation(direction);
            }
            
            bullet.Seek(target, enemy, _t.damage, _t.extraGold, _t.slowPct);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _t.range);
    }
}
