using UnityEngine;

public class TeammateMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalLimit;
    [SerializeField] private float _forwardSpeed;

    private Transform _targetPoint;

    public Transform TargetPoint { get { return _targetPoint; } set { _targetPoint = value;} }

    Vector3 _targetPosition;

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        _targetPosition = _targetPoint.position;

        _targetPosition.x = Mathf.Clamp(_targetPosition.x, -_horizontalLimit, _horizontalLimit);

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _forwardSpeed);
    }
}
