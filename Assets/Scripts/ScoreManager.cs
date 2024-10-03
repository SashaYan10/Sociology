using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;
    public int maxScore;
    public Text scoreText; // Посилання на Text елемент у інтерфейсі Unity.

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int additionalScore)
    {
        totalScore += additionalScore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = totalScore + "/" + maxScore;
        }
    }
}
