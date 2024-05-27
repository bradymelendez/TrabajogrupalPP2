using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<IHittable>().GetDamage(5);
        }
    }
}