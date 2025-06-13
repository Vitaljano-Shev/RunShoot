using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private float _rotateYAngle;
    private void Start()
    {
        transform.Rotate(0, _rotateYAngle, 0);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * _speedMovement;        
    }
}
