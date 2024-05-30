using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CentralBase : Structure
{
    public int woodStored = 0;
    public int stoneStored = 0;
    public int ironStored = 0;
    private bool playerInBase = false;
    private ResourceInventory playerInventory;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBase = true;
            playerInventory = other.GetComponent<ResourceInventory>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBase = false;
            playerInventory = null;
        }
    }

    void Update()
    {
        if (playerInBase && Input.GetKeyDown(KeyCode.Q))
        {
            StoreResources(playerInventory);
        }

        if (playerInBase && Input.GetKeyDown(KeyCode.R))
        {
            RetrieveResources(playerInventory);
        }
    }

    void StoreResources(ResourceInventory resourceInventory)
    {
        if (resourceInventory == null) return;

        woodStored += resourceInventory.wood;
        stoneStored += resourceInventory.stone;
        ironStored += resourceInventory.iron;

        resourceInventory.wood = 0;
        resourceInventory.stone = 0;
        resourceInventory.iron = 0;
    }

    void RetrieveResources(ResourceInventory resourceInventory)
    {
        if (resourceInventory == null) return;

        resourceInventory.wood += woodStored;
        resourceInventory.stone += stoneStored;
        resourceInventory.iron += ironStored;

        woodStored = 0;
        stoneStored = 0;
        ironStored = 0;
    }

    public override void Build()
    {
        Debug.Log("CentralBase construida");
    }

    public override void Upgrade()
    {
        Debug.Log("CentralBase mejorada");
    }
}
