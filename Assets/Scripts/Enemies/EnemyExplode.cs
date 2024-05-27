using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExplode : Enemy
{
    [SerializeField] float areaExplode;
    [SerializeField] GameObject areaAttack;
    [SerializeField] float cooldownAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        phasePlayer = new ExplodePhase(transform,areaExplode);
        phaseStructure = new MeleePhase(areaAttack,cooldownAttack);
        areaAttack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ExecuteEnemy();
    }
}
