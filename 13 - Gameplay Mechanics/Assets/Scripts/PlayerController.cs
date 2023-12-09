using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameController = GameController.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(gameController.focalPointForward * gameController.verticalInput * gameController.playerSpeed);
        gameController.playerPowerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        if(transform.position.y < -1 && !gameController.gameOver) {
            gameController.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Powerup")) {
            gameController.playerHasPowerUp = true;
            gameController.playerPowerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && gameController.playerHasPowerUp) {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromPlayer * gameController.powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name
             + " with powerup set to " + gameController.playerHasPowerUp);
        }
    }

    private IEnumerator PowerUpCountdownRoutine() {
        yield return new WaitForSeconds(gameController.powerUpSeconds);
        gameController.playerPowerUpIndicator.SetActive(false);
        gameController.playerHasPowerUp = false;
    }
}
