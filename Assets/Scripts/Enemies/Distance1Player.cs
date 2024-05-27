using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Distance1Player : IEnemyPhase
{
    Transform pointShoot;
    GameObject bullet;
    float cooldownAttack;
    float time;

    public Distance1Player(GameObject bullet,Transform pointShoot,float cooldownAttack)
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
            for (int i = 0; i < 3; i++)
            {
                GameObject inst = MonoBehaviour.Instantiate(bullet,pointShoot.position,pointShoot.rotation);
                inst.transform.localScale *= 2;
                time = 0;
            }
        }
    }
}