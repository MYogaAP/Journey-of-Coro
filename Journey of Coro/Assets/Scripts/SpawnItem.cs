using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] GameObject[] itemSpawnLocation;
    [SerializeField] GameObject[] itemPrefabs;

    void Start()
    {
        for (int counter = 0; counter < itemSpawnLocation.Length; counter++)
        {
            Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], itemSpawnLocation[counter].transform.position, Quaternion.identity);
        }
        TrackItem.TotalItems = itemSpawnLocation.Length;
    }

    void Update()
    {
        
    }
}
