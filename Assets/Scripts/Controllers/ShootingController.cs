using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator _animator;
    [Header("Shoot Setings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _reloadTime;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private string _shootingString;

    private bool _shooting;

    public GameObject BulletPrefab { get { return _bulletPrefab; } set { _bulletPrefab = value; } }

    private Coroutine _shootCoroutine;
    public void StartShoot()
    {
        _shooting = true;
        AnimateShooting(_shooting, _shootingString);
        if (_shootCoroutine != null) return; 
            
        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    { 
        _shooting = false;
        AnimateShooting(_shooting, _shootingString);
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }
    }

    private void AnimateShooting(bool isShooting, string shootString)
    {
        _animator.SetBool(shootString, isShooting);
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_reloadTime);
            MakeShoot(_bulletPrefab);
        }
    }

    private void MakeShoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, _shootingPoint.position, Quaternion.identity, null);
    }

}
