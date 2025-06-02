using UnityEngine;

public class GarbageCollectorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }   
}
