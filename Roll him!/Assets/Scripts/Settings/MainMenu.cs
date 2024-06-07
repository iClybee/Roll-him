using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("- - - - - - Canvas - - - - - -")]
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private Canvas mainMenuCanvas;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        mainMenuCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void PlayButton()
    {
        audioManager.PlaySFX(audioManager.click);

        if (PlayerPrefs.HasKey("GameProgress"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("GameProgress"));
        }
        
        else
            SceneManager.LoadScene(1);
    }

    public void Settings(bool isOpened)
    {
        audioManager.PlaySFX(audioManager.click);

        if (isOpened)
        {
            mainMenuCanvas.enabled = false;
            settingsCanvas.enabled = true;
        }

        else
        {
            mainMenuCanvas.enabled = true;
            settingsCanvas.enabled = false;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
