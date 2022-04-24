/*
 * Josh McGrew
 * Assignment 8 Prototype 5
 * target script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        targetRb = GetComponent<Rigidbody>();

        //add a force upwards, multiplied by a randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add torque with randomized xyz values
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //set the position with a randomized x value
        transform.position = RandomPosition();
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

}
