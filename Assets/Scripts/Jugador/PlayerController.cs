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
    public float fireRate = 0.5f; 
    private float nextFireTime = 0f;

    private int currentWeapon = 1; 

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

       
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Trophies.TryUnlock(234040);
            currentWeapon = 2;
        }

        
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            if (currentWeapon == 1)
            {
                Shoot(bulletPrefab1);
            }
            else if (currentWeapon == 2)
            {
                Shoot(bulletPrefab2);
            }
            
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
