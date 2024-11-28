using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ScoreCounter : MonoBehaviour
{
    // Public variable to assign the TextMeshPro UI component
    public TMP_Text scoreText;

    // The score value
    private int score = 0;

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    // Call this method to increase the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Update the score display
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}