using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Structure
{
    public int health = 50;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public float attackRange = 10f;
    public float bulletSpeed = 20f;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                if (Time.time >= nextFireTime)
                {
                    Shoot(hitCollider.transform);
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        }
    }

    void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = (target.position - firePoint.position).normalized * bulletSpeed;
    }



    public override void Build()
    {
        Debug.Log("Torre construida");
    }

    public override void Upgrade()
    {    
    Debug.Log("Torre mejorada");
     }

    public void TakeDamage(float amount)
    {
        health -= (int)amount;
        if (health <= 0)
        {            
            Debug.Log("Torre ha sido destruida");
        }
    }
}
