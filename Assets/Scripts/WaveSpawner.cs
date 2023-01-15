using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int noOfenemies;
    public GameObject[] typeOfEnemies;
    public float SpawnInterval;
}
public class WaveSpawner : MonoBehaviour
{

    [SerializeField] Wave[] waves;
    [SerializeField] Transform[] spawners;
    //[SerializeField] private AudioSource crowSoundEffect;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = true;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 00 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            SpawnNextWave();
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (canSpawn == true && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomSpawn = spawners[Random.Range(0, spawners.Length)];
            Instantiate(randomEnemy, randomSpawn.position, Quaternion.identity);
            currentWave.noOfenemies--;
            nextSpawnTime = Time.time + currentWave.SpawnInterval;
            if (currentWave.noOfenemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
