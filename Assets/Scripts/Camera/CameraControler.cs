using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField] private Transform _target;

    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = new Vector3(_offset.x, _offset.y, _target.position.z + _offset.z);
    }
}
