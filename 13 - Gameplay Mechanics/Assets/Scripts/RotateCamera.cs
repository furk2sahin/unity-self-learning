using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    { 
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, gameController.horizontalInput * gameController.cameraRotationSpeed * Time.deltaTime);
    }
}
