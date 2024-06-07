using UnityEngine;

public class TeleportPlatformDisposable : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject portalTwo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destination.gameObject.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(portalTwo);
        }
    }
}
