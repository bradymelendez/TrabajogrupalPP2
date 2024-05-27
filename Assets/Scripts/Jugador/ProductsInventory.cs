using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsInventory : MonoBehaviour
{
    public static ProductsInventory instance;
    public int products;

    private void Start()
    {
        instance = this;
    }
    public void AddProducts()
    {
        products++;
    }
}
