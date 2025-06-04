using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private EnemyHealth _enemyHealth;

    [SerializeField] private float _damage;

    [SerializeField] private GameObject _coinPrefab;
    [Range(1,100)]
    [SerializeField] private int _coinSpawnChance;

    private TeamController _teamController;

    private void Start()
    {
        _enemyHealth.CoinPrefab = _coinPrefab;
        _enemyHealth.CoinSpawnChance = _coinSpawnChance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teammate"))
        {
            _teamController = GameObject.Find("Player").GetComponent<TeamController>();
            _teamController.DealDamage(_damage);

            _enemyHealth.Die(_coinPrefab,_coinSpawnChance);
        }
    }

}
