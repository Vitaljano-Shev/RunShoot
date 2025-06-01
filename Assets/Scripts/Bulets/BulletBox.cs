using UnityEngine;

public class BulletBox : MonoBehaviour
{
    [Header("Bullet Info")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletTimer;

    [Header("Components")]
    [SerializeField] private TeamController _teamController;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        _teamController.SetBulletType(_bulletPrefab, _bulletTimer);
    }
}
