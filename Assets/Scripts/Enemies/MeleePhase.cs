using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePhase : IEnemyPhase
{
    GameObject areaDamage;
    float cooldownAttack;
    float time;

    public MeleePhase(GameObject areaDamage,float cooldownAttack)
    {
        this.areaDamage = areaDamage;
        this.cooldownAttack = cooldownAttack;
    }

    public void Execute()
    {
        time += Time.deltaTime;
        if(time >= cooldownAttack)
        {
            areaDamage.SetActive(true);
            time = 0;
        }
        else
        {
            areaDamage.SetActive(false);
        }
    }
}
