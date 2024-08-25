using UnityEngine;
using UnityEngine.SceneManagement; // for scene management

public class StartScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("GameScene"); // Replace GameScene with the name of the main mechanics scene
    }
}
