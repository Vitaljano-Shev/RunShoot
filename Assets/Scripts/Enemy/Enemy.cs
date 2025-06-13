using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isMelee = false;
    [SerializeField] private bool _isHorde = false;
    public bool IsHorde { get { return _isHorde; } }

    [SerializeField] private EnemyHealth _enemyHealth;

    [SerializeField] private float _meleeDamage;

    [Header("Loot Info")]
    [SerializeField] private GameObject _coinPrefab;
    [Range(1,100)]
    [SerializeField] private int _coinSpawnChance;

    private TeamController _teamController;
    private ShootingController _shootingController;

    private void Start()
    {
        _enemyHealth.CoinPrefab = _coinPrefab;
        _enemyHealth.CoinSpawnChance = _coinSpawnChance;

        if (!_isMelee)
        {
            _shootingController = GetComponent<ShootingController>();
        }
    }

    public void StartShoot()
    {
        _shootingController.StartShoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teammate"))
        {
            _teamController = GameObject.Find("Player").GetComponent<TeamController>();
            if(_meleeDamage != 0) _teamController.DealDamage(_meleeDamage);

            _enemyHealth.Die(_coinPrefab,_coinSpawnChance);
        }
    }

}
