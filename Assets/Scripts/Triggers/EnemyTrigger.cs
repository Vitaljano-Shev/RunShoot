using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{

    [SerializeField] private List<Collider> _enemiesList;

    [Header("Scripts")] 
    [SerializeField] private TeamController _teamController;

    public int EnemyAmount{ get { return _enemiesList.Count; } private set { } }

    private void OnTriggerEnter(Collider other)
    {
        if(!_enemiesList.Contains(other))
        {
            _enemiesList.Add(other);
            _teamController.CheckShoot(_enemiesList.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_enemiesList.Contains(other))
        {
            _enemiesList.Remove(other);
            _teamController.CheckShoot(_enemiesList.Count);
        }
    }
}
