using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // DESIGN PATTERN: SINGLETON
    public static GameManager Instance { get; private set; }
    public HighScoreSystem HighScoreSystem { get; private set; }
    public UIManager UIManager { get; private set; }
    private static float secondsSinceStart = 0;
    private static int score;
    void Awake()
    {
        HighScoreSystem = GetComponent<HighScoreSystem>();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        UIManager = GetComponent<UIManager>();
    }
    void Update()
    {
        secondsSinceStart += Time.deltaTime;
        Instance.UIManager.UpdateTimeUI(secondsSinceStart);
    }
    public static string GetScoreText()
    {
        return score.ToString();
    }
    public static void IncrementScore(int value)
    {
        score += value;
        Instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Score: " + score);
    }
    public static void ResetGame()
    {
        Time.timeScale = 1f;
        ResetScore();
        secondsSinceStart = 0f;
    }
    private static void ResetScore()
    {
        score = 0;
        Instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Score: " + score);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        MenuController.IsGamePaused = true;
        Instance.UIManager.ActivateEndGame(score);
        HighScoreSystem.CheckHighScore("Player", score);
    }
}
