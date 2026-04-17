using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BerryUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI berryNumber;


    public void UpdateAmount()
    {
        berryNumber.text = PlayerPrefs.GetInt("Berry", 0).ToString();
    }
}
