using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeeds : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject weedPrefab;
    private void Start()
    {
        int spawnCount = spawnPoints.Length / 2;
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnWeed();
        }
    }   
    private void SpawnWeed()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        Instantiate(weedPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }
    
}
