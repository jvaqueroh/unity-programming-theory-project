using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected Rigidbody obstacleRigidBody;
    protected float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        obstacleRigidBody.AddForce(-Vector3.forward * speed);
    }
}
