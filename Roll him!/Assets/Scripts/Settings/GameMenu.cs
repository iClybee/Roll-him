using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameMenu : MonoBehaviour
{
    [Header("- - - - - - GameObject - - - - - -")]
    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject pauseMenu;

    AudioManager audioManager;
    GameObject obj;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FirstTutor"))
        {
            GUI.SetActive(true);
        }

        else
            GUI.SetActive(false);

        pauseMenu.SetActive(false);

        YandexGame.FullscreenShow();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void MenuButton() //Канвас с меню
    {
        audioManager.PlaySFX(audioManager.click);

        pauseMenu.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0;
    }

    public void MainMenuButton() //кнопка "в главное меню"
    {
        audioManager.PlaySFX(audioManager.click);

        PlayerPrefs.SetInt("LevelSave", SceneManager.GetActiveScene().buildIndex);
        obj = GameObject.Find("AudioControl");
        Destroy(obj);
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1;
    }

    public void ResumeButton() //кнопка "продолжить"
    {
        audioManager.PlaySFX(audioManager.click);

        pauseMenu.SetActive(false);
        GUI.SetActive(true);

        Time.timeScale = 1;
    }

    public void ContinueButton() //кнопка "дальше"
    {
        audioManager.PlaySFX(audioManager.click);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1;
    }

    public void EndGameButton() //"конечная" кнопка
    {
        audioManager.PlaySFX(audioManager.click);

        obj = GameObject.Find("AudioControl");
        Destroy(obj);

        PlayerPrefs.DeleteKey("GameProgress");
        SceneManager.LoadScene("MainMenu");

        Time.timeScale = 1;
    }
}
