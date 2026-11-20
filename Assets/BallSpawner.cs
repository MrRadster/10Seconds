using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Balls")]
    public Transform[] balls;

    [Header("Spawn Area")]
    public float minX = -3.5f;
    public float maxX = 3.5f;
    public float minZ = -3f;
    public float maxZ = 0.5f;
    public float spawnHeight = 0.5f;

    void Start()
    {
        SpawnBallsRandomly();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnBallsRandomly();
        }
    }

    void SpawnBallsRandomly()
    {
        foreach (Transform ball in balls)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            ball.position = new Vector3(randomX, spawnHeight, randomZ);
        }
    }
}