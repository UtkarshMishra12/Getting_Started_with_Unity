using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalPrefabs;
    [SerializeField]
    private float startDelay = 2.0f;
    [SerializeField]
    private float spawnInterval = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnpos = new Vector3(Random.Range(-20, 20), 0, 20);
        int AnimalIndex = Random.Range(0, AnimalPrefabs.Length);
        Instantiate(AnimalPrefabs[AnimalIndex], spawnpos, AnimalPrefabs[AnimalIndex].transform.rotation);
    }
}
