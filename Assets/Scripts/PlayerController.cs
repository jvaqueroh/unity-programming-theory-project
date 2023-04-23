using Assets.Scripts;
using UnityEngine;

public class PlayerController : MovingObject
{
    [SerializeField] private int health = 100;
    [SerializeField] private int zBoundaryMax = 0;
    private Rigidbody playerRigidBody;
    private readonly float horizontal_speed = 30.0f;
    private readonly float vertical_speed = 20.0f;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.NotifyHealthChange(health);
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!gameManager.IsGameActive) return;
        base.Update();
    }

    protected override void Move()
    {
        playerRigidBody.AddForce(Input.GetAxis("Horizontal") * horizontal_speed * Vector3.right);
        if (transform.position.z > zBoundaryMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundaryMax);
        }
        else
        {
            playerRigidBody.AddForce(Input.GetAxis("Vertical") * vertical_speed * Vector3.forward);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        gameManager.NotifyHealthChange(health);
        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    protected override void OnOutOfBoundaries()
    {
        base.OnOutOfBoundaries();
        gameManager.GameOver();
    }
}
