using TMPro;
using UnityEngine;

public class MyQualitySettings : MonoBehaviour
{

    public TMP_Dropdown qualityDropdown; //выпадающее меню с качеством картинки

    private void Start()
    {
        LoadQuality();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettigs()
    {
        PlayerPrefs.SetInt("QualityPref", qualityDropdown.value);
    }

    private void LoadQuality()
    {
        if (PlayerPrefs.HasKey("QualityPref"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualityPref");
        }

        else
            qualityDropdown.value = 3;
    }
}
