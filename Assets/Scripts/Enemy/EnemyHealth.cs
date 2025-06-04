using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float _health;

    [SerializeField] private Collider _collider;

    private GameObject _coinPrefab;
    public GameObject CoinPrefab {set { _coinPrefab = value; } }

    private int _coinSpawnChance;
    public int CoinSpawnChance { set {_coinSpawnChance = value;} }


    private EnemyTrigger _enemyTrigger;
    public EnemyTrigger EnemyTrigger { set { _enemyTrigger = value; } }

    public void DealDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die(_coinPrefab,_coinSpawnChance);
        }
    }

    public void Die(GameObject objectToSpawn, int spawnChance)
    {
        if (_enemyTrigger.EnemyList.Contains(_collider))
        {
            _enemyTrigger.EnemyList.Remove(_collider);
            _enemyTrigger.CheckShootInTeam();
        }
        Destroy(gameObject);

        if(spawnChance >= Random.Range(1, 101))
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity, null);
        }

    }

}
