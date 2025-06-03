using System.Collections;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Spawn Info")]
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject[] _spawnPrefabs;

    [Header("Enemy Spawn Info")]
    [SerializeField] private float _enemySpawnIntervalTime;
    [SerializeField] private int _minEnemySpawnAmount, _maxEnemySpawnAmount;
    [SerializeField] private float _leftEnemySpawnValue, _rightEnemySpawnValue;

    private Coroutine _enemyHordeSpawnCoroutine;

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

        if (randomSpawnPrefab.CompareTag("Enemy"))
        {
            _enemyHordeSpawnCoroutine = StartCoroutine(EnemyHordeSpawnCoroutine(randomSpawnPrefab, randomSpawnPoint, _enemySpawnIntervalTime));
        }
        else
        {
            Instantiate(randomSpawnPrefab, randomSpawnPoint.position, Quaternion.identity, transform);
        }
    }

    private IEnumerator EnemyHordeSpawnCoroutine(GameObject enemy, Transform spawnPoint, float enemySpawnIntervalTime)
    {
        int enemySpawnAmount = Random.Range(_minEnemySpawnAmount, _maxEnemySpawnAmount + 1);

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            float enemyXAxeSpawnPoint = Random.Range(_leftEnemySpawnValue, _rightEnemySpawnValue);
            Vector3 newSpawnPosition = new Vector3(enemyXAxeSpawnPoint, spawnPoint.position.y, spawnPoint.position.z);

            Instantiate(enemy, newSpawnPosition, Quaternion.identity, transform);

            yield return new WaitForSeconds(enemySpawnIntervalTime);
        }
    }

}
