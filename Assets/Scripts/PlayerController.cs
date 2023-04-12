using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private readonly float horizontal_speed = 30.0f;
    private readonly float vertical_speed = 20.0f;
    private int health = 100;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRigidBody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGameActive) return;

        playerRigidBody.AddForce(Input.GetAxis("Horizontal") * horizontal_speed * Vector3.right);
        playerRigidBody.AddForce(Input.GetAxis("Vertical") * vertical_speed * Vector3.forward);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player health: {health}");
        if (health <= 0)
        {
            Debug.Log($"Game Over!");
            gameManager.GameOver();
        }
    }
}
