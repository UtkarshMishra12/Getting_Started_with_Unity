using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;
    private float startdelay = 2.0f;
    private float interval = 2.2f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacles", startdelay, interval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void SpawnRandomObstacles()
    {
        int Index = Random.Range(0, Obstacles.Length);
        Vector3 spawnpos = new Vector3(25, 0, 0);
        if (playerControllerScript.gameOver==false)
        {
            Instantiate(Obstacles[Index], spawnpos, Obstacles[Index].transform.rotation);
        }
        
    }
}
