using Assets.Scripts;
using UnityEngine;

public class Obstacle : MovingObject
{
    protected Rigidbody obstacleRigidBody;
    private PlayerController playerController;
    private GameManager gameManager;
    protected float speed = 20.0f;
    protected int strength = 10;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRigidBody = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();
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

    protected override void OnOutOfBoundaries()
    {
        base.OnOutOfBoundaries();
        gameManager.NotifyObstaclePassed(strength);
    }
}
