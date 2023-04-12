using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive { get; set; }
    [SerializeField] private float obstaclesDelay = 3.0f;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        IsGameActive = true;
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(obstaclesDelay);
            spawnManager.SpawnObstacle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
