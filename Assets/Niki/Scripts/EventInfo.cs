using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventInfo : MonoBehaviour
{
    public GameObject linkedMarker;

    [SerializeField] public TextMeshProUGUI title;
    [SerializeField] private string wantedTitle;

    [SerializeField] private TextMeshProUGUI basicInfo;
    [SerializeField] private string address;
    [SerializeField] private string times;

    [SerializeField] private TextMeshProUGUI longInfo;
    [SerializeField] private string wantedInfo;

    [SerializeField] private TextMeshProUGUI meters;


    [SerializeField] public GameObject dir;

    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        linkedMarker = GameObject.Find(linkedMarker.name + "(Clone)");

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

        var directions = Instantiate(dir, GameObject.Find("DirSpot").transform);

        directions.gameObject.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title.text;

        menuManager.activeObject = gameObject;

        menuManager.dirTarget = linkedMarker;
        
        menuManager.Route();
        
    }
}
