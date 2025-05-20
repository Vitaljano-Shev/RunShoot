using System.Collections.Generic;
using UnityEngine;

public class TeamPointsController : MonoBehaviour
{
    [Header("Teammate Info")]
    [SerializeField] private GameObject _teammatePrefab;
    [SerializeField] private int _teammateAmount;
    [SerializeField] private List<TeammateManager> _teammates = new List<TeammateManager>();

    private TeammateManager teammateManager;

    [Header("Team Points Info")]
    [SerializeField] private Transform[] _teamPoints;

    private void Start()
    {
        //_teamPoints = new Transform[_teammateAmount];
    }

    public void AddTeammate()
    {
        if (_teammates.Count <= _teamPoints.Length)
        {
            int index = _teammates.Count;

            GameObject newTeammate = Instantiate(_teammatePrefab, _teamPoints[index].position,Quaternion.identity);

            teammateManager = newTeammate.GetComponent<TeammateManager>();
            _teammates.Add(teammateManager);
            teammateManager.Initialize(_teamPoints[index]);
        }

    }
}
