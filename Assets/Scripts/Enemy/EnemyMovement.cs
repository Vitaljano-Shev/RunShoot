using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;

    private void Start()
    {
        transform.Rotate(0, 180, 0);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * _speedMovement;        
    }
}
