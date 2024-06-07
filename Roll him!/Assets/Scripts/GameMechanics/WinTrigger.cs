using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [Header("- - - - - -Barrier - - - - - -")]
    [SerializeField] private float blockVert = 2f;
    [SerializeField] private float blockHor = 2f;

    [Space(10)]
    [Header("- - - - - - GameObject - - - - - -")]
    [SerializeField] private GameObject congratulation;
    [SerializeField] private GameObject GUI;

    AudioManager audioManager;

    private void Start()
    {
        congratulation.SetActive(false);
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void SaveProgress(int levelIndex)
    {
        PlayerPrefs.SetInt("GameProgress", levelIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.CompareTag("WinTrigger"))
        {
            Object @object = other.gameObject;
            Destroy(@object);
            PlayerPrefs.SetInt("GameProgress", SceneManager.GetActiveScene().buildIndex + 1);

            audioManager.PlaySFX(audioManager.levelComplete);

            GUI.SetActive(false);
            congratulation.SetActive(true);

            Time.timeScale = 0;
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
