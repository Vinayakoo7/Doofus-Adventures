using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Reference to the Game Over canvas
    public TextMeshProUGUI gameOverText; // Reference to the Game Over text
    public GameObject scoreCanvas; // Reference to the Score canvas

    void Start()
    {
        // we hide the Game Over canvas at the start
        gameOverCanvas.SetActive(false);
    }

    public void TriggerGameOver()
    {
        //I want to have the game over text display above Doofus instead of a seperate screen and I wanna watch him fall
        
        // we show the Game Over canvas
        gameOverCanvas.SetActive(true);

        // here we are hiding the score canvas
        if (scoreCanvas != null)
        {
            scoreCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Score Canvas not assigned.");
        }
    }

    public void RestartGame()
    {
        // here we are reloading the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
