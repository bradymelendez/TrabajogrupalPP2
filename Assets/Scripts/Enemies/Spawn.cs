using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    static public Spawn instance;
    [SerializeField] GameObject[] enemies;
    List<GameObject> enemiesSpawned;
    [SerializeField] float timeToNextWave;

    void Start()
    {
        enemiesSpawned = new List<GameObject>();
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(SpawnEnemies());
        }
    }

    public void RemoveEnemy(GameObject enemyDestroy)
    {
        enemiesSpawned.Remove(enemyDestroy);

        if(enemiesSpawned.Count() <= 0)
        {
            StartSpawn();
        }
    }

    void StartSpawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeToNextWave);

        int posX = 0;
        for (int i = 0; i < 10; i++)
        {
            posX = Random.Range(-5,6);
            Vector3 posSpawn = new Vector3(transform.position.x + posX,transform.position.y,transform.position.z);
            int a = Random.Range(0,enemies.Length);

            GameObject enemy = Instantiate(enemies[a],posSpawn,Quaternion.identity);

            enemiesSpawned.Add(enemy);
            yield return new WaitForSeconds(1);
        }
    }
}
