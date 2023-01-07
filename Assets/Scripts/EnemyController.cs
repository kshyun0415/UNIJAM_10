using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Invoke("MakeEnemy",2);
}
}

    void MakeEnemy(){
        int randEnemy= Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint=Random.Range(0,spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

    }
}
