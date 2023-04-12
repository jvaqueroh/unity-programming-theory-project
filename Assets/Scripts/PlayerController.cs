using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private readonly float speed = 30.0f;
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        playerRigidBody.AddForce(Input.GetAxis("Horizontal") * speed * Vector3.right);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player health: {health}");
        if (health <= 0)
        {
            Debug.Log($"Game Over!");
        }
    }
}
