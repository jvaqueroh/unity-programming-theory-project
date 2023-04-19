using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive { get; set; }

    [SerializeField] private float obstaclesDelay = 3.0f;
    [SerializeField] private Button backToMenuButton;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    SpawnManager spawnManager;
    private int totalScore = 0;
    private int currentLevel;
    private int levelUpStep = 100;

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
        backToMenuButton.gameObject.SetActive(true);
    }

    //ToDo: implement as event
    public void NotifyHealthChange(int remainingHealth) {
        
        healthText.text = $"Health: {remainingHealth}";
    }

    //ToDo: implement as event
    public void NotifyObstaclePassed(int points)
    {
        totalScore += points;
        scoreText.text = $"Score: {totalScore}";

        CheckDifficulty(totalScore);
    }

    private void CheckDifficulty(int totalScore)
    {
        var level = totalScore / levelUpStep;

        if(level > currentLevel)
        {
            currentLevel = level;
            obstaclesDelay -= 0.1f;
        }

        if(level % 10 == 0)
        {
            levelUpStep += 20;
        }
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
