using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalLimit;
    [SerializeField] private float _horizontalSensivityKeyboard, _horizontalSensivityPoint;

    private float _horizontalValue, _valueX;
    private Vector3 _targetPosition;
    private Camera _camera;

    private void Start()
    {
        _targetPosition = transform.position;
        _camera = Camera.main;
    }
    void Update()
    {
        MoveForward();
        MoveLeftRightKeyboard();
        MoveLeftRightPoint();
    }
    
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);
    }

    private void MoveLeftRightKeyboard()
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

        //if (_valueX != 0f )
        //{
            _targetPosition += Vector3.right * _valueX * _horizontalSensivityKeyboard * Time.deltaTime;
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, -_horizontalLimit, _horizontalLimit);

            Vector3 limitedTargetPosition = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, limitedTargetPosition, 0.2f); 
       // }
    }
    private void MoveLeftRightPoint()
    {
        Vector2 screenPosition = Vector2.zero;
        bool isActive = false;
        if(Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
            isActive = true;
        }
        else if (Mouse.current.leftButton.isPressed)
        {
            screenPosition = Mouse.current.position.ReadValue();
            isActive = true;
        }

        if (!isActive) return;

        Ray ray = _camera.ScreenPointToRay(screenPosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if(plane.Raycast(ray, out float enter))
        {
            Vector3 worldTargetPosition = ray.GetPoint(enter);
            worldTargetPosition.x = Mathf.Clamp(worldTargetPosition.x, -_horizontalLimit, _horizontalLimit);

            Vector3 limitedWorldTargetPosition = new Vector3(worldTargetPosition.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, limitedWorldTargetPosition, _horizontalSensivityPoint);
            _targetPosition = transform.position;
        }
    }
}
