using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] private float blockVert = 2f;
    [SerializeField] private float blockHor = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.CompareTag("LoseTrigger"))
        {
            SceneManager.LoadScene("Level1");
        }

        else if (other.CompareTag("WallVertical") && this.CompareTag("WinTrigger"))
        {
            Vector3 offset = new Vector3(0, 0, blockVert);
            other.transform.position = other.transform.position - offset;
        }

        else if (other.CompareTag("WallHorizontal") && this.CompareTag("WinTrigger"))
        {
            Vector3 offset = new Vector3(blockHor, 0, 0);
            other.transform.position = other.transform.position - offset;
        }
    }
}
