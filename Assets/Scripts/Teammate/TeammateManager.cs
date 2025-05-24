using UnityEngine;

public class TeammateManager : MonoBehaviour
{

    [SerializeField] private TeammateMovement _teammateMovement;
    [SerializeField] private ShootingController _shootingController;

    public ShootingController ShootingController { get { return _shootingController; } private set { } }

    public void Initialize(Transform targetPoint)
    {
        _teammateMovement.TargetPoint = targetPoint;
    }

}
