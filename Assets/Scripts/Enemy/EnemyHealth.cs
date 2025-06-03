using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float _health;

    [SerializeField] private Collider _collider;

    private EnemyTrigger _enemyTrigger;
    public EnemyTrigger EnemyTrigger { set { _enemyTrigger = value; } }

    public void DealDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (_enemyTrigger.EnemyList.Contains(_collider))
        {
            _enemyTrigger.EnemyList.Remove(_collider);
            _enemyTrigger.CheckShootInTeam();
        }
        Destroy(gameObject);
    }

}
