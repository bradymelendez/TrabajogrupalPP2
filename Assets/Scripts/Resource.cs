using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Iron
    }

    public ResourceType type;
    public int amount;

    public int GetAmount()
    {
        return amount;
    }
}
