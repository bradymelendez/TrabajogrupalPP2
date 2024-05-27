using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour,IHittable
{
    [SerializeField] int life;

    public void GetDamage(int damage)
    {
        life -= damage;
    }
}
