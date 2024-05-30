using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private Rigidbody rb;
    private Vector3 movement;
    public int health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot(bulletPrefab1, 1);
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            Shoot(bulletPrefab2, 2);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot(GameObject bulletPrefab, int damage)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;
        bullet.GetComponent<Bullet>().damage = damage;
    }

    public void TakeDamage(float amount)
    {
        health -= (int)amount;
        if (health <= 0)
        {            
            Debug.Log("Player ha sido derrotado");
        }
    }
}
