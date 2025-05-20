using UnityEngine;

public class ArchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<TeamPointsController>().AddTeammate();
        }
    }
}
