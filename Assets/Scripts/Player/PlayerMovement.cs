using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSensivity, _horizontalLimit;

    private float _horizontalValue, _valueX;
    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }
    void Update()
    {
        MoveForward();
        MoveLeftRight();
    }
    
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }

    private void MoveLeftRight()
    {
        _horizontalValue = Input.GetAxis("Horizontal");

        switch (_horizontalValue)
        {
            case (0):
                _valueX = 0f;
                break;
            case (< 0):
                _valueX = -1f;
                break;
            case (> 0):
                _valueX = 1f;
                break;
            default:
                _valueX = 0f;
                break;
        }

        _targetPosition += Vector3.right * _valueX * _horizontalSensivity * Time.deltaTime;
        _targetPosition.x = Mathf.Clamp(_targetPosition.x, -_horizontalLimit, _horizontalLimit);

        Vector3 limitedTargetPosition = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, limitedTargetPosition, 0.2f);
    }
}
