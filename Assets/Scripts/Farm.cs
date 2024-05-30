using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Structure
{
    public int woodRequired;
    public int stoneRequired;
    public GameObject productPrefab;
    public Transform productSpawnPoint;

    public override void Build()
    {
        Debug.Log("Building Farm...");
    }

    public override void Upgrade()
    {
        Debug.Log("Upgrading Farm...");
    }

    private void ProduceProduct()
    {
        Instantiate(productPrefab, productSpawnPoint.position, productSpawnPoint.rotation);
    }
}
