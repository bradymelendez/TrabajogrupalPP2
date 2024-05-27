using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDistance1 : Enemy
{
    [SerializeField] Transform pointShoot;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldownAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        phasePlayer = new Distance1Player(bullet,pointShoot,cooldownAttack);
        phaseStructure = new Distance1(bullet,pointShoot,cooldownAttack);
    }

    void Update()
    {
        ExecuteEnemy();
    }
}
