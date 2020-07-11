using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 1000f;
    public float slowingSpeed = 1f;
    public float gravityModifier = 0.5f;
    float mouseXInput;
    float mouseYInput;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed -= Time.deltaTime * slowingSpeed * 100f;
        //Debug.Log("Plane: Current speed is " + currentSpeed.ToString("0"));
    }

    private void Start()
    {
        //forward force
        rb.AddForce(transform.forward * speed);
    }

    private void FixedUpdate()
    {
        

        //static up force
        rb.AddForce(Vector3.up * Time.fixedDeltaTime * 10000f / gravityModifier);
    }
}
