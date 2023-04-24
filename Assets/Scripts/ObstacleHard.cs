using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHard : Obstacle // INHERITANCE
{
    private float directionModifier = 1.0f;

    public ObstacleHard() : base()
    {
        strength = 20;
    }

    protected override void Move() // POLYMORPHISM
    {
        base.Move();
        obstacleRigidBody.AddForce(Vector3.right * directionModifier * speed);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        directionModifier *= -1.0f;
    }
}
