using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public PulpitManager pulpitManager; // Reference to the PulpitManager
    public float scoreIncrement = 0.1f; // Score increment for each new pulpit

    private Vector3 lastPulpitPosition;

    void Start()
    {
        LoadPlayerSettings();
        lastPulpitPosition = transform.position; // Initialize last position
    }

    void Update()
    {
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
    }

    bool HasMovedToNewPulpit()
    {
        // Assuming each pulpit is of size 9x9 and checking if Doofus has moved beyond the bounds of the last pulpit
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
