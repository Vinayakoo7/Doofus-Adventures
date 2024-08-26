using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public PulpitManager pulpitManager; // Reference to the PulpitManager
    public float scoreIncrement = 0.1f; // Score increment for each new pulpit
    public GameObject gameOverUI; // Reference to the Game Over UI
    public GameObject scoreTextUI; // Reference to the Score Text UI

    private Vector3 lastPulpitPosition;
    private bool isGameOver = false; // Track whether the game is over

    void Start()
    {
        LoadPlayerSettings();
        lastPulpitPosition = transform.position; // Initialize last position
    }

    void Update()
    {
        if (isGameOver) return; // Stop movement if the game is over

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Check if Doofus has moved to a new pulpit
        if (HasMovedToNewPulpit())
        {
            pulpitManager.OnDoofusMovedToNewPulpit(scoreIncrement);
            lastPulpitPosition = transform.position; // Update last position
        }

        // Check if player falls below a certain Y threshold (e.g., Y < -5)
        if (transform.position.y < -5f)
        {
            TriggerGameOver();
        }
    }

    bool HasMovedToNewPulpit()
    {
        float threshold = 9f; // Pulpit size or threshold distance to consider as moved to a new pulpit
        return Vector3.Distance(transform.position, lastPulpitPosition) >= threshold;
    }

    void LoadPlayerSettings()
    {
        string path = "Assets/Scripts/player_data.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            speed = data.player_data.speed;
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true; // Set the game as over
        gameOverUI.SetActive(true); // Show the game over UI
        scoreTextUI.SetActive(false); // Hide the score text UI
    }
}

[System.Serializable]
public class PlayerData
{
    public PlayerAttributes player_data;

    [System.Serializable]
    public class PlayerAttributes
    {
        public float speed;
    }
}
