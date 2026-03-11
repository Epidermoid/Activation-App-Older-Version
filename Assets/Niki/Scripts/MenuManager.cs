using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject paikat;

    [SerializeField] private GameObject karttaBottomBar;
    [SerializeField] private GameObject paikatBottomBar;

    [SerializeField] private GameObject infoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void karttaButton()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Info"));

        paikat.SetActive(false);
    }
    public void karttaButtonNoDestroy()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);

        paikat.SetActive(false);
    }



    public void paikatButton()
    {
        karttaBottomBar.SetActive(false);
        paikatBottomBar.SetActive(true);

        paikat.SetActive(true);
    }


    public void OpenSchoolTemp()
    {
        var infoTab = Instantiate(infoPrefab, GameObject.Find("PaikatList").transform);
    }

    public void SchoolRouteTemp()
    {
        var infoTab = Instantiate(infoPrefab, GameObject.Find("PaikatList").transform);
        infoTab.gameObject.tag = "Active";
        karttaButtonNoDestroy();

        
        var directions = Instantiate(infoTab.GetComponent<EventInfo>().dir, GameObject.Find("DirSpot").transform);

        directions.gameObject.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = infoTab.GetComponent<EventInfo>().title.text;
    }
}
