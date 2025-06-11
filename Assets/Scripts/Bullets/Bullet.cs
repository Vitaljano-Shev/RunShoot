using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;

    [SerializeField] private Color _bulletUIColor;
    public Color BulletUIColor { get { return _bulletUIColor; } }

    void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            Destroy(gameObject);
            enemyHealth.DealDamage(_damage);
        }
    }

}
