using UnityEngine;

public class TeammateManager : MonoBehaviour
{

    [SerializeField] private TeammateMovement _teammateMovement;

    public void Initialize(Transform targetPoint)
    {
        _teammateMovement.TargetPoint = targetPoint;
    }

}
