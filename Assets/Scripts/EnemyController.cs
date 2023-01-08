using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject[] peoplePrefabs;

    public GameObject[] benefitsPrefabs;

    float K = 0;
    float I = 0;
    float U = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        K += Time.deltaTime;
        if(K>=1.5f)
        {   
            MakeEnemy();
            K=0;
        }
        I += Time.deltaTime;
        if(I>=5f)
        {
            MakeBenefit();
            I=0;
        }

        U += Time.deltaTime;
        if(U>=7f)
        {
            MakePeople();
            U=0;
        }
    }


    void MakeBenefit()
    {
        int randEnemy= Random.Range(0, benefitsPrefabs.Length);
        int randSpawnPoint=Random.Range(0,spawnPoints.Length);
        Instantiate(benefitsPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

    }
    void MakeEnemy(){
        int randEnemy= Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint=Random.Range(0,spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
    void MakePeople(){
        int randEnemy= Random.Range(0, peoplePrefabs.Length);
        int randSpawnPoint=Random.Range(0,spawnPoints.Length);
        Instantiate(peoplePrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

    }
}
