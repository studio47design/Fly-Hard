using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"{MainManager.Instance.GetName()} - Score: {score}";

        if (score > (MainManager.Instance.GetHighScore()))
        {
            MainManager.Instance.SetHighScore($"Highscore - {MainManager.Instance.GetName()}: {score}", score);
            highScoreText.text = MainManager.Instance.GetHighScoreString();

        }
        else return;

    }

    public void GameOver()
    {
        MainManager.Instance.SaveHighScore();
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
