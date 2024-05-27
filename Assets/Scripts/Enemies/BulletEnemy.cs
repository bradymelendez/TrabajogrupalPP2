using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocity;
    
    void Start()
    {
        Destroy(gameObject,5);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward *velocity;
    }
}
