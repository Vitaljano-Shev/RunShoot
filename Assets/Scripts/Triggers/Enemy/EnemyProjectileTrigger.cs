using UnityEngine;

public class EnemyProjectileTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private void OnTriggerEnter(Collider other)
    {
        _enemy.StartShoot();
    }

}
