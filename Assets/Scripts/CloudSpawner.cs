using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float spawnInterval = 4f;
    [SerializeField] private float spawnXPosition = 10f;
    [SerializeField] private float minY = 2f;
    [SerializeField] private float maxY = 4f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0f);
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
    }
}