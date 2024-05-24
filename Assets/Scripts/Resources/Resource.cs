using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : MonoBehaviour
{
    public enum ResourceType
    {
        wood,
        stone,
        iron
    }
    public int amount;
    public ResourceType type;

    public int GetAmount()
    {
        return amount;
    }
}
