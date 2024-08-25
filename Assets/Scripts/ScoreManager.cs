using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    private float score = 0f;
    void Start()
    {
        // Initialize score display
        UpdateScoreDisplay();
    }
    public void IncreaseScore(float increment)
    {
        score += increment;
        UpdateScoreDisplay();
    }
    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            // Multiply the score by 10 and convert to an integer for display
            int displayScore = Mathf.RoundToInt(score * 10);
            scoreText.text = "Score: " + displayScore.ToString();
        }
        else
        {
            Debug.LogError("Score TextMeshProUGUI component is not assigned.");
        }
    }
}
