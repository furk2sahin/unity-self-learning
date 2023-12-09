using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAnimation : MonoBehaviour
{
    private float multiplier = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0 || transform.position.y > 0.5) multiplier *= -1;
        
        transform.position = transform.position + Vector3.up * Time.deltaTime * multiplier;
        transform.Rotate(Vector3.up, -1);
    }
}
