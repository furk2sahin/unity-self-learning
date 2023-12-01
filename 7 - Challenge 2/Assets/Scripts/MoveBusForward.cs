using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBusForward : MonoBehaviour
{
    public List<GameObject> wheels;
    public float speed = 5.0f;
    private float wheelDegree = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        wheelDegree = (wheelDegree +  Time.deltaTime) % 360;
        foreach(GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.right, wheelDegree);
        }
    }
}
