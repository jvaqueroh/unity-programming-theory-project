using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody obstacleRigidBody;
    private PlayerController playerController;
    protected float speed = 20.0f;
    protected int strength = 10;
    private readonly float zBoundary = -7.0f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidBody = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundaries();
    }

    protected virtual void Move()
    {
        obstacleRigidBody.AddForce(-Vector3.forward * speed);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.TakeDamage(strength);
        }
    }

    private void CheckBoundaries()
    {
        if (transform.position.z < zBoundary)
        {
            Destroy(gameObject);
        }
    }
}
