using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Spawn Info")]
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _spawnPrefabs;

    private ChunkSpawner _chunkSpawner;
    public ChunkSpawner ChunkSpawner { get { return _chunkSpawner; } set { _chunkSpawner = value; } }

    private void Start()
    {
        SpawnObjects();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _chunkSpawner.StepedOnNextChunk(transform.position.z);
        }
    }

    private void SpawnObjects()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        GameObject randomSpawnPrefab = _spawnPrefabs[Random.Range(0, _spawnPrefabs.Length)];

        Instantiate(randomSpawnPrefab, randomSpawnPoint.position, Quaternion.identity, transform);
    }

}
