using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {
        LoadPlayerSettings();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void LoadPlayerSettings()
    {
        string path = "Assets/player_data.json";
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
