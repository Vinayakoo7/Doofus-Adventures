using UnityEngine;
using System.Collections;
using System.IO;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab; // Assign your Pulpit prefab here
    public float minDestroyTime = 4f;
    public float maxDestroyTime = 5f;
    public float spawnTime = 2.5f;

    private GameObject currentPulpit;
    private Vector3 lastPulpitPosition;

    void Start()
    {
        LoadPulpitSettings();
        SpawnInitialPulpit();
    }

    void LoadPulpitSettings()
    {
        string filePath = Path.Combine(Application.dataPath, "player_data.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PulpitData data = JsonUtility.FromJson<PulpitData>(json);
            minDestroyTime = data.pulpit_data.min_pulpit_destroy_time;
            maxDestroyTime = data.pulpit_data.max_pulpit_destroy_time;
            spawnTime = data.pulpit_data.pulpit_spawn_time;
        }
        else
        {
            Debug.LogError("player_data.json file not found in Assets folder!");
        }
    }

    void SpawnInitialPulpit()
    {
        lastPulpitPosition = Vector3.zero;
        currentPulpit = Instantiate(pulpitPrefab, lastPulpitPosition, Quaternion.identity);
        StartCoroutine(DestroyAndSpawnPulpit(currentPulpit));
    }

    IEnumerator DestroyAndSpawnPulpit(GameObject pulpit)
    {
        // Wait for a random destroy time
        float destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
        yield return new WaitForSeconds(destroyTime);

        // Destroy the current pulpit
        Destroy(pulpit);

        // Spawn the next pulpit
        SpawnNextPulpit();
    }

    void SpawnNextPulpit()
    {
        // Calculate a new random position adjacent to the last pulpit
        Vector3 newPosition = GetRandomAdjacentPosition(lastPulpitPosition);
        currentPulpit = Instantiate(pulpitPrefab, newPosition, Quaternion.identity);
        lastPulpitPosition = newPosition;

        // Start the destruction process for the new pulpit
        StartCoroutine(DestroyAndSpawnPulpit(currentPulpit));
    }

    Vector3 GetRandomAdjacentPosition(Vector3 position)
    {
        // Choose a random direction to move
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 direction = directions[Random.Range(0, directions.Length)];

        // Return the new position by moving in the chosen direction
        return position + direction * pulpitPrefab.transform.localScale.x;
    }
}

[System.Serializable]
public class PulpitData
{
    public PulpitAttributes pulpit_data;

    [System.Serializable]
    public class PulpitAttributes
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }
}
