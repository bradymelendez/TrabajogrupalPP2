using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Distance2 : IEnemyPhase
{
    Transform pointShoot;
    GameObject bullet;
    float cooldownAttack;
    float time;
    Vector3 posSpaw;

    public Distance2(GameObject bullet,Transform pointShoot,float cooldownAttack)
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
            posSpaw = pointShoot.position;
            posSpaw.x += 0.5f;
            MonoBehaviour.Instantiate(bullet,pointShoot.position,pointShoot.rotation);
            MonoBehaviour.Instantiate(bullet,posSpaw,pointShoot.rotation);
            posSpaw.x -= 1f;
            MonoBehaviour.Instantiate(bullet,posSpaw,pointShoot.rotation);
            time = 0;
        }
    }
}