using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive { get; set; }
    [SerializeField] private float obstaclesDelay = 3.0f;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI healthText;
    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        IsGameActive = true;
        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        IsGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }

    public void NotifyHealthChange(int remainingHealth) {
        healthText.text = $"Health: {remainingHealth}";
    }

    private IEnumerator SpawnObstacles()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(obstaclesDelay);
            spawnManager.SpawnObstacle();
        }
    }
}
