using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance2Player : IEnemyPhase
{
    Transform pointShoot;
    GameObject bullet;
    float cooldownAttack;
    float time;
    Vector3 posSpaw;

    public Distance2Player(GameObject bullet,Transform pointShoot,float cooldownAttack)
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
            GameObject inst = MonoBehaviour.Instantiate(bullet,pointShoot.position,pointShoot.rotation);
            inst.transform.localScale *= 2;

            inst = MonoBehaviour.Instantiate(bullet,posSpaw,pointShoot.rotation);
            inst.transform.localScale *= 2;

            posSpaw.x -= 1f;
            inst = MonoBehaviour.Instantiate(bullet,posSpaw,pointShoot.rotation);
            inst.transform.localScale *= 2;
            time = 0;
        }
    }
}
