using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private EnemyHealth _enemyHealth;

    [SerializeField] private float _damage;

    private TeamController _teamController;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teammate"))
        {
            _teamController = GameObject.Find("Player").GetComponent<TeamController>();
            _teamController.DealDamage(_damage);

            _enemyHealth.Die();
        }
    }

}
