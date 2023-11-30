using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public int propellerRotateDegree = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        propellerRotateDegree = (propellerRotateDegree + 1) % 180;
        transform.Rotate(Vector3.forward, propellerRotateDegree);
    }
}
