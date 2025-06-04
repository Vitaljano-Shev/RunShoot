using UnityEngine;

public class Coin : MonoBehaviour
{

    private TeamController _teamController;

    private void OnTriggerEnter(Collider other)
    {

        _teamController = GameObject.Find("Player").GetComponent<TeamController>();

        Destroy(gameObject);

        _teamController.AddCoin();
    }
}
