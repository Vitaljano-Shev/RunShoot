using UnityEngine;

public class BulletBox : MonoBehaviour
{
    [Header("Bullet Info")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletTimer;

    [Header("Components")]
    private TeamController _teamController;

    private void Start()
    {
       _teamController =  GameObject.Find("Player").GetComponent<TeamController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _teamController.SetBulletType(_bulletPrefab, _bulletTimer);
    }
}
