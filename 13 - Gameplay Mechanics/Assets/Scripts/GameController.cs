using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public bool gameOver = false;
    public float cameraRotationSpeed = 50.0f;
    public float enemySpeed = 3.0f;
    public float autoSpawnRange = 9.0f;
    public bool playerHasPowerUp = false;
    public float powerUpStrength = 15.0f;
    public float powerUpSeconds = 7.0f;
    public float horizontalInput;
    public float verticalInput;
    public Vector3 focalPointForward;
    public GameObject playerPowerUpIndicator;
    public int livingEnemyCount = 0;
    public int enemyCountToSpawn = 1;
    public int waveNumber = 1;

    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(gameOver) {
            verticalInput = 0;
        } else {
            verticalInput = Input.GetAxis("Vertical");
        }
        focalPointForward = focalPoint.transform.forward;
        livingEnemyCount = FindObjectsOfType<Enemy>().Length;
    }

    public static GameController GetInstance() {
        return GameObject.Find("GameController").GetComponent<GameController>();
    }
}
