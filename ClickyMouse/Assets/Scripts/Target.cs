using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed =12;
    private float maxSpeed = 15;
    private float maxTorque = 10;
    private float xRange = 4;
    private float yRange = -2;
    public int pointValue;
    private GameManager gameManager;
    public ParticleSystem explosionPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(),RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.PlaySound();
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up* Random.Range(minSpeed,maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }
}
