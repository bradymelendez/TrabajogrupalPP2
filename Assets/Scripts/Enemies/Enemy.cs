using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour,IHittable
{
    protected Transform player;
    [SerializeField] protected GameObject[] structure;
    protected Transform selectStructure;
    protected float disPlayer;
    protected float disStructure;
    [SerializeField] protected float rangeAttack;
    protected NavMeshAgent agent;
    protected IEnemyPhase phase;
    protected IEnemyPhase phasePlayer;
    protected IEnemyPhase phaseStructure;
    protected int life;

    public virtual void ExecuteEnemy()
    {
        disPlayer = (player.position - transform.position).sqrMagnitude;
        if(selectStructure == null)
        {
            if (!(phase is ExplodePhase))
            {
                phase = phasePlayer;
            }
            SearchStructure();
            if(disPlayer > rangeAttack)
            {
                
                agent.isStopped = false;
                agent.destination = player.position;
            }
            else
            {
                agent.isStopped = true;
                phase.Execute();
            }
        }
        else
        {
            disStructure = (selectStructure.position - transform.position).sqrMagnitude;
            if(disPlayer < disStructure)
            {
                if (!(phase is ExplodePhase))
                    {
                        phase = phasePlayer;
                    }
                if(disPlayer > rangeAttack)
                {
                    
                    agent.isStopped = false;
                    agent.destination = player.position;
                }
                else
                {
                    agent.isStopped = true;
                    phase.Execute();
                }
            }
            else
            {
                if (!(phase is MeleePhase))
                {
                    phase = phaseStructure;
                }
                if(disStructure > rangeAttack)
                {
                    
                    agent.isStopped = false;
                    agent.destination = selectStructure.position;
                }
                else
                {
                    agent.isStopped = true;
                    phase.Execute();
                }
            }
        }
    }

    public void GetDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnDestroy()
    {
        if(Spawn.instance != null)
        Spawn.instance.RemoveEnemy(gameObject);
    }

    public void SearchStructure()
    {
        structure = GameObject.FindGameObjectsWithTag("Structure");

        foreach (var item in structure)
        {
            if(item != null)
            {
                if(selectStructure == null)
                {
                    selectStructure = item.transform;
                }
                else
                {
                    float disFocus = (selectStructure.position - transform.position).sqrMagnitude;
                    float disNew = (item.transform.position - transform.position).sqrMagnitude;

                    if(disNew < disFocus)
                    {
                        selectStructure = item.transform;
                    }
                }
            }
        }
    }
}
