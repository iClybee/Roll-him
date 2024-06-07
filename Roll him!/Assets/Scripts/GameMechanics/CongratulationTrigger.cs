using UnityEngine;

public class CongratulationTrigger : MonoBehaviour
{
    [Header("- - - - - - Barrier - - - - - -")]
    [SerializeField] private float blockVert = 2f;
    [SerializeField] private float blockHor = 2f;

    [Header("- - - - - - GameObject - - - - - -")]
    [SerializeField] private GameObject thanks;
    [SerializeField] private GameObject GUI;

    AudioManager audioManager;

    private void Start()
    {
        thanks.SetActive(false);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.CompareTag("WinTrigger"))
        {   
            Object @object = other.gameObject;
            Destroy(@object);

            Time.timeScale = 0;

            PlayerPrefs.DeleteKey("LevelSave");

            audioManager.PlaySFX(audioManager.levelComplete);

            thanks.SetActive(true);
            GUI.SetActive(false);
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
