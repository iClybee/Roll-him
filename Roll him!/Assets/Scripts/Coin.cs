using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{   
    [SerializeField] private float rotateZ;
    [SerializeField] private float posY;
    [SerializeField] private float wave;

    private void FixedUpdate()
    {
        this.gameObject.transform.Rotate(0, 0, rotateZ);
        this.gameObject.transform.position = new Vector3(transform.position.x, posY + Mathf.Sin(Time.fixedTime) * wave, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
