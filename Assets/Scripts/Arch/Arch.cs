using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Arch : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] MeshRenderer _meshRenderer;
    [SerializeField] Material _positiveMaterial, _negativeMaterial;

    [Header("UI")]
    [SerializeField] private TMP_Text _teammateAmountText; 
    [SerializeField] private int _negativeTeammateAmount, _positiveTeammateAmount;

    private ArchController _archController;
    public ArchController ArchController { set { _archController = value; } }

    private int _teammateAmount = 0;
    
    private void Start()
    {
        GenerateTeammateAmount();
        SetVisual();
    }
    private void GenerateTeammateAmount()
    {
        while (_teammateAmount == 0)
        {
            _teammateAmount = Random.Range(_negativeTeammateAmount, _positiveTeammateAmount+1);
        }
    }

    private void SetVisual()
    {
        char symbol = ' ';
        if(_teammateAmount < 0)
        {
            _meshRenderer.material = _negativeMaterial;
        }
        else
        {
            _meshRenderer.material = _positiveMaterial;
            symbol = '+';
        }

        _teammateAmountText.text = symbol + _teammateAmount.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _archController.AcrhActivated();
            if (_teammateAmount > 0)
            {
                other.GetComponent<TeamController>().AddTeammate(_teammateAmount);
            }
            else
            {
                other.GetComponent<TeamController>().RemoveTeammate(_teammateAmount * (-1));
            }
        }
    }
}
