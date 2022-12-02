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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
