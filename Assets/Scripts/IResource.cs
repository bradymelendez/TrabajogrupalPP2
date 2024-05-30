using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResource 
{
    int GetAmount();
    ResourceType GetResourceType();
}

public enum ResourceType
{
    Wood,
    Stone,
    Iron
}
