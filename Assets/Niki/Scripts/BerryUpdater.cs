using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BerryUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI berryNumber;
    [SerializeField] private TextMeshProUGUI redBerryNumber;
    [SerializeField] private TextMeshProUGUI goldBerryNumber;


    public void UpdateAmount()
    {
        berryNumber.text = PlayerPrefs.GetInt("Berry", 0).ToString();
        redBerryNumber.text = PlayerPrefs.GetInt("RedBerry", 0).ToString();
        goldBerryNumber.text = PlayerPrefs.GetInt("GoldBerry", 0).ToString();
    }
}
