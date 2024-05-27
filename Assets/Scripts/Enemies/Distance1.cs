using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance1 : IEnemyPhase
{
    Transform pointShoot;
    GameObject bullet;
    float cooldownAttack;
    float time;

    public Distance1(GameObject bullet,Transform pointShoot,float cooldownAttack)
    {
        this.bullet = bullet;
        this.pointShoot = pointShoot;
        this.cooldownAttack = cooldownAttack;
    }

    public void Execute()
    {
        time += Time.deltaTime;

        if(time > cooldownAttack)
        {
            MonoBehaviour.Instantiate(bullet,pointShoot.position,pointShoot.rotation);
            time = 0;
        }
    }

}
