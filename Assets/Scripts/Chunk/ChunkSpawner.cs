using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [Header("Chunk Info")]
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private int _chunkAmountAtStart;
    [SerializeField] private float _chunkLength;
    [SerializeField] private int _startSpawnEnemyAtChunkIndex;

    private void Start()
    {
        for (int i = 0; i < _chunkAmountAtStart; i++)
        {
            if (i >= _startSpawnEnemyAtChunkIndex - 1)
            {
                SpawnChunk(new Vector3(0, 0, _chunkLength * i), _chunkPrefab, true);
            }
            else
            {
                SpawnChunk(new Vector3(0, 0, _chunkLength * i), _chunkPrefab);
            }
        }
    }

    public void StepedOnNextChunk(float zAxis)
    {
        SpawnChunk(new Vector3(0, 0, zAxis + (_chunkAmountAtStart * _chunkLength)), _chunkPrefab, true);
    }

    private void SpawnChunk(Vector3 spawnPosition, GameObject chunkToSpawn, bool spawnEnemy = false)
    {
        GameObject newChunk = Instantiate(chunkToSpawn, spawnPosition, Quaternion.identity, transform);

        newChunk.GetComponent<Chunk>().ChunkSpawner = this;
        newChunk.GetComponent<Chunk>().CanSpawnEnemy = spawnEnemy;
    }

}
