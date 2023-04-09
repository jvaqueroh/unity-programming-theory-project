using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private float speed = 30.0f;
    private int health = 100;
    private bool gameActive = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player health: {health}");
        if (health <= 0)
        {
            gameActive = false;
            Debug.Log($"Game Over!");
        }
    }
}
