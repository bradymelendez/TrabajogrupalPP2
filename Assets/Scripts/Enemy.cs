using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float attackDamage = 5f;
    public float attackRange = 1f;
    public float moveSpeed = 3.5f;
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        FindTarget();
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);

            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                Attack();
            }
        }
        else
        {
            FindTarget();
        }
    }

    void FindTarget()
    {
        // Prioritiza encontrar la torre primero
        GameObject tower = GameObject.FindWithTag("Tower");
        if (tower != null)
        {
            target = tower.transform;
        }
        else
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    void Attack()
    {
        if (target.CompareTag("Tower"))
        {
            target.GetComponent<Tower>().TakeDamage(attackDamage);
        }
        else if (target.CompareTag("Player"))
        {
            target.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }

        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
