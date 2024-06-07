using UnityEngine.Localization.Settings;
using UnityEngine;
using TMPro;

public class LocalSelector : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown localizationDropdown;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LocaleKey"))
        {
            localizationDropdown.value = PlayerPrefs.GetInt("LocaleKey");
        }

        else
            localizationDropdown.value = 0;
    }

    public void SaveLocale()
    {

        PlayerPrefs.SetInt("LocaleKey", localizationDropdown.value);
    }

     public void SetLocale(int _localeID)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
    }
}
