using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;

    public ParticleSystem explosionParicle;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos(){
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown() {
        if(gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParicle, transform.position, explosionParicle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }

    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
