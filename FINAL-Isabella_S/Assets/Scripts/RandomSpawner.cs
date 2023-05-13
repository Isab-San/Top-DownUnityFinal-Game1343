using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //int randEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefab[0], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }
}
