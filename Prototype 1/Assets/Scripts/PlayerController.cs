using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    public float horizontalInput;
    public float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Move vehicle forward
        //Jalankan Mobil Kedepan
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput * jump);

        //Jalankan Mobil Kesamping
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
