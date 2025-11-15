using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeeds : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject weedPrefab;
    [SerializeField] private int weeds = 41;

    public int spawnCount => spawnPoints.Length / 2;
    

    private List<GameObject> weedPool = new List<GameObject>();
    private void Awake()
    {
        for(int i = 0; i< weeds; i++)
        {
            GameObject weed = Instantiate(weedPrefab);
            weed.SetActive(false);
            weedPool.Add(weed);
        }
    }
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
        GameObject weed = GetWeedPool();
        if (weed == null) return;

        Transform spawnPoint = GetRandomSpawnPoint();

        weed.transform.position = spawnPoint.position;
        weed.transform.rotation = spawnPoint.rotation;
        weed.SetActive (true);
    }
    private GameObject GetWeedPool()
    {
        for(int i = 0; i<weedPool.Count;i++)
        {
            if (!weedPool[i].activeSelf)
            {
                return weedPool[i];
            }
        }
        return null;
    }
    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }
    
}
