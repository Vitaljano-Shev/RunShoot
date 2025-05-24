using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private TeamController _teamController;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        _teamController.AddCoin();
    }
}
