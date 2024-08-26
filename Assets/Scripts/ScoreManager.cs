using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score = 0f;

    void Start()
    {
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
            int displayScore = Mathf.RoundToInt(score * 10);
            scoreText.text = displayScore.ToString() + "\nScore";}
        else
        {
            Debug.LogError("Score component not assigned.");
        }
    }

    public void HideScore()
    {
        scoreText.gameObject.SetActive(false);
    }
}
