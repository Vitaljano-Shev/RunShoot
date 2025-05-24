using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] float _bulletLifeTime;
    [SerializeField] float _bulletSpeed;

    void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
    }


    void Update()
    {
        transform.position += transform.forward * _bulletSpeed;
    }
}
