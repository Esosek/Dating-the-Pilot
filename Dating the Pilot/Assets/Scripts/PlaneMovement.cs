using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    public float speed = 1000f;
    public float slowingSpeed = 1f;
    public float rotationSpeed = 5f;
    public float maxModelRotation = 2f;
    public float modelRotationSpeed = 1f;
    public float gravityModifier = 0.5f;
    public Transform planeModel;
    public Transform crosshair;

    Vector2 screenCenter;
    Vector2 mouseDistance;
    Vector2 lookInput;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        screenCenter.x = Screen.width / 2;
        screenCenter.y = Screen.height / 2;
    }

    void Update()
    {
        speed -= Time.deltaTime * slowingSpeed;
        //Debug.Log("Plane: Current speed is " + currentSpeed.ToString("0"));

        Tilting();
    }

    private void FixedUpdate()
    {
        //forward force
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime + -Vector3.up * gravityModifier * Time.fixedDeltaTime;

        //static up force
        //rb.AddForce(Vector3.up * Time.fixedDeltaTime * 10000f / gravityModifier);
    }

    void Tilting()
    {
        lookInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mouseDistance = new Vector2((lookInput.x - screenCenter.x) / screenCenter.y, (lookInput.y - screenCenter.y) / screenCenter.y);

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // crosshair move
        crosshair.localPosition = new Vector3 (mouseDistance.x * 100f, 0f, 0f);

        // model rotation
        Quaternion targetRotation = Quaternion.Euler (0f, mouseDistance.x * maxModelRotation, -mouseDistance.x * maxModelRotation);
        planeModel.localRotation = Quaternion.Lerp(planeModel.localRotation, targetRotation, Time.deltaTime * modelRotationSpeed);

        transform.Rotate(0f, mouseDistance.x * rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
