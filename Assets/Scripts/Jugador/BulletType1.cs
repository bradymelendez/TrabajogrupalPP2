using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType1 : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public float lifeTime = 3f; 

    void Start()
    {
        Trophies.TryUnlock(234039);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime); 
    }

    void OnCollisionEnter(Collision collision)
    {
        
        //Para cuando hagan los enemigos
    }
}
