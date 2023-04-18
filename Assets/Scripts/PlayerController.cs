using Assets.Scripts;
using UnityEngine;

public class PlayerController : MovingObject
{
    [SerializeField] private int health = 100;
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
        base.Update();
        if (!gameManager.IsGameActive) return;

        playerRigidBody.AddForce(Input.GetAxis("Horizontal") * horizontal_speed * Vector3.right);
        playerRigidBody.AddForce(Input.GetAxis("Vertical") * vertical_speed * Vector3.forward);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player health: {health}");
        gameManager.NotifyHealthChange(health);
        if (health <= 0)
        {
            Debug.Log($"Game Over!");
            gameManager.GameOver();
        }
    }

    protected override void OnOutOfBoundaries()
    {
        base.OnOutOfBoundaries();
        Debug.Log($"Game Over!");
        gameManager.GameOver();
    }
}
