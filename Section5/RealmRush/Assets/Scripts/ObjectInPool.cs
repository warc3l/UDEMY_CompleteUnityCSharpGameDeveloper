using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] [Range(0.1f, 30f)] private float spawnTime = 1.0f;

    [SerializeField] [Range(0, 50)] private int poolSize = 5;
    // Start is called before the first frame update
    private GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }


    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false) {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    
    

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
