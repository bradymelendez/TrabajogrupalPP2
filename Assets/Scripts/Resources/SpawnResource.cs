using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnResource : MonoBehaviour
{
    public GameObject prefabResource;
    private GameObject spawnResource;
    public float timeWaitSpawn;
    private float timer;
    void Start()
    {
        spawnResource = GameObject.Instantiate(prefabResource, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnResource == null)
        {
            timer += Time.deltaTime;
            if (timer >= timeWaitSpawn )
            {
                spawnResource = GameObject.Instantiate(prefabResource, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
}
