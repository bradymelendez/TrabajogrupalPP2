using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodePhase : IEnemyPhase
{
    float areaExplode;
    Transform transform;

    public ExplodePhase(Transform transform,float areaExplode)
    {
        this.transform = transform;
        this.areaExplode = areaExplode;
    }

    public void Execute()
    {
        Collider[] area = Physics.OverlapSphere(transform.position,areaExplode);

        foreach (var item in area)
        {
            if(item.gameObject.tag == "Player")
            {
                item.gameObject.GetComponent<IHittable>().GetDamage(5);
            }
        }

        GameObject.Destroy(transform.gameObject);
    }

}
