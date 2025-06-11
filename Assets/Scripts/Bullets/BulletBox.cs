using UnityEngine;

public class BulletBox : MonoBehaviour
{
    [Header("Bullet Info")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletTimer;

    [Header("Components")]
    private TeamController _teamController;

    private void OnTriggerEnter(Collider other)
    {
        _teamController = GameObject.Find("Player").GetComponent<TeamController>();
        Destroy(gameObject);
        _teamController.SetBulletType(_bulletPrefab, _bulletTimer);
    }
}
