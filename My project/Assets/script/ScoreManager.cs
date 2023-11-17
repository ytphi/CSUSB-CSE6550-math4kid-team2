using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private const string ScoreKey = "PlayerScore";
    public TextMeshProUGUI scoreText;

    private int currentScore;

    void Start()
    {
        // Load player score when the game starts
        LoadPlayerScore();

        // Update UI with initial player score
        UpdateScoreUI();
    }

    void Update()
    {
        // For testing purposes, increase the score when you press the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore();
        }
    }

    public void IncreaseScore()
    {
        // Increase the player's score
        currentScore++;
        SavePlayerScore();

        // Log the updated score
        Debug.Log("Score Increased! New Score: " + currentScore);

        // Update the UI text to display the current score
        UpdateScoreUI();
    }

    void LoadPlayerScore()
    {
        // Load player score or set to 0 if it doesn't exist
        currentScore = PlayerPrefs.GetInt(ScoreKey, 0);
        Debug.Log("Player score loaded: " + currentScore);
    }

    void SavePlayerScore()
    {
        // Save player score
        PlayerPrefs.SetInt(ScoreKey, currentScore);
        PlayerPrefs.Save();
    }

    void UpdateScoreUI()
    {
        // Update the UI text with the player's current score
        if (scoreText != null)
        {
            scoreText.text = " " + currentScore;
        }
    }
}
