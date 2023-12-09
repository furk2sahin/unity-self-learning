using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidBody;
    private GameController gameController;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.GetInstance();
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10) {
            Destroy(gameObject);
        }
        if(gameController.gameOver) return;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidBody.AddForce(lookDirection * gameController.enemySpeed);
    }
}
