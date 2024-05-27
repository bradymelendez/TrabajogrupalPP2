using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : Enemy
{
    [SerializeField] GameObject weapon;
    [SerializeField] float cooldownAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        weapon.SetActive(false);
        phasePlayer = new MeleePhase(weapon,cooldownAttack);
        phaseStructure = new MeleePhase(weapon,cooldownAttack);
    }

    void Update()
    {
        ExecuteEnemy();
    }
}
