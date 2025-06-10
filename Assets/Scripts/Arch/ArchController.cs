using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchController : MonoBehaviour
{

    [SerializeField] GameObject _archPrefab;
    [SerializeField] Transform _leftArchSpawmPoint, _rightArchSpawmPoint;

    private List<GameObject> _arches = new List<GameObject>();
    private Coroutine _archActivatedDelayCoroutine;

    private void Start()
    {
        GenerateArch();
    }

    private void GenerateArch()
    {
        int randomArchSpawnNumber = Random.Range(0, 3);

        switch (randomArchSpawnNumber)
        {
            case 0:
                SpawnArch(_leftArchSpawmPoint);
                break;
            case 1:
                SpawnArch(_rightArchSpawmPoint);
                break;
            case 2:
                SpawnArch(_leftArchSpawmPoint);
                SpawnArch(_rightArchSpawmPoint);
                break;
            default:
                break;
        }
    }

    private void SpawnArch(Transform acrhSpawnPoint)
    {
        GameObject generatedArch =  Instantiate(_archPrefab, acrhSpawnPoint.position, Quaternion.identity, acrhSpawnPoint);
        generatedArch.GetComponent<Arch>().ArchController = this;
        _arches.Add(generatedArch);
    }

    public void AcrhActivated()
    {
        if(_archActivatedDelayCoroutine == null)
        {
            _archActivatedDelayCoroutine = StartCoroutine(ArchActivatedDelayCoroutine());
        }
    }

    private IEnumerator ArchActivatedDelayCoroutine()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
        //foreach (GameObject arch in _arches)
        //{
        //    Destroy(arch);
        //}
    }
}
