using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiDistance2 : Enemy
{
    [SerializeField] Transform pointShoot;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldownAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        phasePlayer = new Distance2Player(bullet,pointShoot,cooldownAttack);
        phaseStructure = new Distance2(bullet,pointShoot,cooldownAttack);
    }

    void Update()
    {
        ExecuteEnemy();
    }
}