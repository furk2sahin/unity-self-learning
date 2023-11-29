using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private float speed = 10.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        if (forwardInput > 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (forwardInput < 0.0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
        }

        // We turn the vehicle
        if (horizontalInput > 0.0f)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);
        }
        else if (horizontalInput < 0.0f)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * -1);
        }
    }
}
