using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacleEasy;
    [SerializeField] private GameObject obstacleNormal;
    [SerializeField] private GameObject obstacleHard;
    private readonly float xRange = 3.2f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnObstacle), 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        var i = Random.Range(0, 3);
        switch (i)
        {
            case 0: Instantiate(obstacleEasy, GenerateSpawnPosition(), obstacleEasy.transform.rotation); break;
            case 1: Instantiate(obstacleNormal, GenerateSpawnPosition(), obstacleNormal.transform.rotation); break;
            case 2: Instantiate(obstacleHard, GenerateSpawnPosition(), obstacleHard.transform.rotation); break;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), .5f, 20.0f);
    }
}
