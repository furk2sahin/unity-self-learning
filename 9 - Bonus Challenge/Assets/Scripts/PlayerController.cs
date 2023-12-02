using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> wheels;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public string inputID;

    // Private Variables
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;
    private float wheelDegree = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Move the vehicle forward
        if (forwardInput > 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            RotateWhells();
        }
        else if (forwardInput < 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
            RotateWhells();
        }

        // We turn the vehicle
        if (horizontalInput > 0.0f)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
            RotateWhells();
        }
        else if (horizontalInput < 0.0f)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * -1);
            RotateWhells();
        }
        changeCamera();
    }

    private void RotateWhells()
    {
        wheelDegree = (wheelDegree + Time.deltaTime) % 360;
        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.right, wheelDegree);
        }
    }

    private void changeCamera()
    {
        if(Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
