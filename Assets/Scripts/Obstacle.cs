using Assets.Scripts;
using UnityEngine;

public class Obstacle : MovingObject
{
    protected Rigidbody obstacleRigidBody;
    private PlayerController playerController;
    protected float speed = 20.0f;
    protected int strength = 10;

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
}
