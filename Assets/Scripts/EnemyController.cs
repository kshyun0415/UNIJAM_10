using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    float Ran;
    float K = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        K += Time.deltaTime;
        if(K>=2)
        {   
            MakeEnemy();
            K=0;
        }
    }



    void MakeEnemy(){
        int randEnemy= Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint=Random.Range(0,spawnPoints.Length);
        Ran = Random.Range(-1,2);
        
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

    }
}
