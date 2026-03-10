using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private string wantedTitle;

    [SerializeField] private TextMeshProUGUI basicInfo;
    [SerializeField] private string address;
    [SerializeField] private string times;

    [SerializeField] private TextMeshProUGUI longInfo;
    [SerializeField] private string wantedInfo;

    [SerializeField] private TextMeshProUGUI meters;

    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        title.text = wantedTitle;
        basicInfo.text = "Osoite: " + address + "\nAukioloaika: " + times;
        longInfo.text = wantedInfo;
    }

    public void BackButton()
    {
        Destroy(gameObject);
    }

    public void GoButton()
    {
        gameObject.tag = "Active";
        menuManager.karttaButtonNoDestroy();
    }
}
