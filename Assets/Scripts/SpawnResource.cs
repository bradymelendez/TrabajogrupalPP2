using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResource : MonoBehaviour
{
    public GameObject prefabResource;    
    public float timeWaitSpawn;
    private float timer;

    void Start()
    {
        SpawnNewResource();
    }

    void Update()
    {
        if (timer >= timeWaitSpawn)
        {
            SpawnNewResource();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void SpawnNewResource()
    {
        Instantiate(prefabResource, transform.position, Quaternion.identity);
    }
}
