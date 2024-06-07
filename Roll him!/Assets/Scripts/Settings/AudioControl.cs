using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    [Header("- - - - - - Music - - - - - -")]
    [SerializeField] private Slider musicSlider;
    private float volumeMusic;

    [Space(10)]
    [Header("- - - - - - SFX - - - - - -")]
    [SerializeField] private Slider sfxSlider;
    private float volumeSFX;

    [Space(10)]
    [Header("- - - - - - Mixer - - - - - -")]
    [SerializeField] private AudioMixer audioMixer;


    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumeMusicPref") || PlayerPrefs.HasKey("VolumeSFXPref"))
        {
            LoadVolume();
        }

        else
        {
            VolumeMusic();
            VolumeSFX();
        }
    }

    public void VolumeMusic()
    {
        volumeMusic = musicSlider.value;
        audioMixer.SetFloat("mixerMusic", Mathf.Log10(volumeMusic) * 20);
    }

    public void VolumeSFX()
    {
        volumeSFX = sfxSlider.value;
        audioMixer.SetFloat("mixerSFX", Mathf.Log10(volumeSFX) * 20);
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("VolumeMusicPref", musicSlider.value);
        PlayerPrefs.SetFloat("VolumeSFXPref", sfxSlider.value);
    }

    private void LoadVolume()
    {
         musicSlider.value = PlayerPrefs.GetFloat("VolumeMusicPref");
         sfxSlider.value = PlayerPrefs.GetFloat("VolumeSFXPref");
    }
}
