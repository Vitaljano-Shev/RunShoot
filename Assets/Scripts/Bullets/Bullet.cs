using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private float _rotateYAngle;

    [SerializeField] private Color _bulletUIColor;
    public Color BulletUIColor { get { return _bulletUIColor; } }

    private TeamController _teamController;

    void Start()
    {
        transform.Rotate(0, _rotateYAngle, 0);
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
        }else if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Teammate"))
        {
            _teamController = GameObject.Find("Player").GetComponent<TeamController>();
            _teamController.DealDamage(_damage);
        }
    }

}
