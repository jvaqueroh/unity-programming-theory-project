using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHard : Obstacle
{
    private float directionModifier = 1.0f;

    protected override void Move()
    {
        base.Move();
        obstacleRigidBody.AddForce(Vector3.right * directionModifier * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        directionModifier *= -1.0f;
    }
}
