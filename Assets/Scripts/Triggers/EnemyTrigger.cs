using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    [SerializeField] private List<Collider> _enemiesList;

    [Header("Scripts")]
    [SerializeField] private TeamController _teamController;

    public int EnemyAmount { get { return _enemiesList.Count; } private set { } }
    public List<Collider> EnemyList { get { return _enemiesList; }}

    private void OnTriggerEnter(Collider other)
    {
        if(!_enemiesList.Contains(other))
        {
            other.GetComponent<EnemyHealth>().EnemyTrigger = this;

            _enemiesList.Add(other);
            //_teamController.CheckShoot(_enemiesList.Count);
            CheckShootInTeam();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_enemiesList.Contains(other))
        {
            _enemiesList.Remove(other);
            CheckShootInTeam();
        }
    }

    public void CheckShootInTeam()
    {
        _teamController.CheckShoot(_enemiesList.Count);
    }

}
