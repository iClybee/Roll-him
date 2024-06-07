using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("- - - - - - AudioSource - - - - - -")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [Header("- - - - - - AudioClip - - - - - -")]
    public AudioClip backgroundMusic;
    public AudioClip backgroundMusic2;
    public AudioClip click;
    public AudioClip click2;
    public AudioClip levelComplete;

    public static AudioManager Instance;

    private void Start()
    {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
