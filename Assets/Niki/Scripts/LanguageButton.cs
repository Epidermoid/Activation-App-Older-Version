using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageButton : MonoBehaviour
{
    public Locale[] locales;

    [SerializeField] private int langInt;

    // Start is called before the first frame update
    void Start()
    {
        langInt = PlayerPrefs.GetInt("Lang", 0);
        LocalizationSettings.SelectedLocale = locales[langInt];
    }

    public void ChangeLanguageUp()
    {
        AudioManager.PlayPop();

        langInt++;
        if (langInt >= locales.Length)
        {
            langInt = 0;
        }

        LocalizationSettings.SelectedLocale = locales[langInt];
        PlayerPrefs.SetInt("Lang", langInt);
    }
    public void ChangeLanguageDown()
    {
        AudioManager.PlayPop();

        langInt--;
        if (langInt < 0)
        {
            langInt = locales.Length-1;
        }

        LocalizationSettings.SelectedLocale = locales[langInt];
        PlayerPrefs.SetInt("Lang", langInt);
    }
}
