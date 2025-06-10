using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField] private ShootingController _playerShootingController;
    [SerializeField] private PlayerHealth _playerHealth;

    [Header("Teammate Info")]
    [SerializeField] private GameObject _teammatePrefab;
    //[SerializeField] private int _teammateAmount;
    [SerializeField] private List<TeammateManager> _teammates = new List<TeammateManager>();

    [Header("Team Points Info")]
    [SerializeField] private Transform[] _teamPoints;

    [Header("Components")]
    [SerializeField] private EnemyTrigger _enemyTrigger;

    [Header("Bullet Type")]
    [SerializeField] private GameObject _bulletDefaultPrefab;

    [Header("Coins")]
    [SerializeField] private int _coinAmount = 0;
    [SerializeField] private TMP_Text _coinAmountText;

    private TeammateManager _teammateManager;
    private Coroutine _newBulletTimer;
    private GameObject _bulletCurrentPrefab;

    private void Start()
    {
        _bulletCurrentPrefab = _bulletDefaultPrefab;
    }

    public void AddTeammate(int teammateAmountToAdd = 1)
    {
        for (int i = 0; i < teammateAmountToAdd; i++)
        {
            if (_teammates.Count < _teamPoints.Length)
            {
                int index = _teammates.Count;

                GameObject newTeammate = Instantiate(_teammatePrefab, _teamPoints[index].position, Quaternion.identity);

                _teammateManager = newTeammate.GetComponent<TeammateManager>();
                _teammates.Add(_teammateManager);
                _teammateManager.Initialize(_teamPoints[index]);

                CheckShoot(_enemyTrigger.EnemyAmount);

                newTeammate.GetComponent<ShootingController>().BulletPrefab = _bulletCurrentPrefab;
            }
            else return;
        }
    }

    public void DealDamage(float damage)
    {
        if(_teammates.Count > 0)
        {
            RemoveTeammate();
        }
        else
        {
            _playerHealth.DealDamage(damage);
        }
    }

    public void RemoveTeammate(int teammateAmountToRemove = 1)
    {
        for (int i = 0; i < teammateAmountToRemove; i++)
        {
            if (_teammates.Count > 0)
            {
                int lastTeammateIndex = _teammates.Count - 1;
                Destroy(_teammates[lastTeammateIndex].gameObject);
                _teammates.RemoveAt(lastTeammateIndex);
            }
            else return;            
        }
    }

    public void CheckShoot(int countOfEnemies)
    {
        if(countOfEnemies > 0)
        {
            _playerShootingController.StartShoot();
            foreach(TeammateManager teammate  in _teammates)
            {
                teammate.ShootingController.StartShoot();
            }
        }
        else
        {
            _playerShootingController.StopShoot();
            foreach(TeammateManager teammate in _teammates)
            {
                teammate.ShootingController.StopShoot();
            }
        }
    }

    public void SetBulletType(GameObject bullet, float bulletTimer)
    {
        _bulletCurrentPrefab = bullet;
        SetBulletTypeToTeam();
        if (_newBulletTimer != null) StopCoroutine(_newBulletTimer);

        _newBulletTimer = StartCoroutine(NewBulletTimer(bulletTimer));
    }

    private IEnumerator NewBulletTimer(float bulletTimer)
    {
        yield return new WaitForSeconds(bulletTimer);
        _bulletCurrentPrefab = _bulletDefaultPrefab;
        SetBulletTypeToTeam();
    }

    private void SetBulletTypeToTeam()
    {
        _playerShootingController.BulletPrefab = _bulletCurrentPrefab;
        foreach(TeammateManager teammate in _teammates)
        {
            teammate.ShootingController.BulletPrefab = _bulletCurrentPrefab;
        }
    }
    
    public void AddCoin()
    {
        _coinAmount++;
        _coinAmountText.text = _coinAmount.ToString();
    }

}
