using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProducts : MonoBehaviour
{
    public float timer = 3f;
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            ProductsInventory.instance.AddProducts();
            time = 0;
        }
    }
}
