using UnityEngine;

public class TeleportPlatformReusable : MonoBehaviour
{
    [SerializeField] private TeleportPlatformReusable destination;

    private bool hasTeleported = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTeleported)
        {
            other.transform.position = destination.gameObject.transform.position;
            destination.hasTeleported = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasTeleported = false;
        }
            
    }
}
