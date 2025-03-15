using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Text component to display the score")]
    public TextMeshProUGUI scoreText;
    
    [Header("Settings")]
    [Tooltip("Starting score value")]
    public int startingScore = 0;
    
    [Tooltip("Points added per collectible")]
    public int pointsPerCollectible = 1;

    // Current score
    private int currentScore;

    private void Start()
    {
        // Initialize score
        currentScore = startingScore;
        UpdateScoreDisplay();
        
        Debug.Log("ScoreManager initialized with score: " + currentScore);
    }

    // Add points to the score
    public void AddPoint()
    {
        currentScore += pointsPerCollectible;
        Debug.Log("Score increased to: " + currentScore);
        UpdateScoreDisplay();
    }

    // Update the UI text
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
            Debug.Log("Updated score display: " + scoreText.text);
        }
        else
        {
            Debug.LogError("Score Text reference is missing!");
        }
    }

    // Get the current score (for other scripts)
    public int GetScore()
    {
        return currentScore;
    }
}