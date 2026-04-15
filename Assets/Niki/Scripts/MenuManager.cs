using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject paikat;

    [SerializeField] private GameObject karttaBottomBar;
    [SerializeField] private GameObject paikatBottomBar;

    public GameObject dirTarget;

    [SerializeField] private GameObject directions;
    [SerializeField] private GameObject cancelRouteButton;

    public GameObject activeObject;

    [SerializeField] private GameObject profilePage;

    [SerializeField] private GameObject characterBottomBar;
    [SerializeField] private GameObject advancementsBottomBar;
    [SerializeField] private GameObject characterBackground;

    [SerializeField] private GameObject characterSelect;
    [SerializeField] private bool characterSelectOpen = false;

    [SerializeField] private GameObject placeSettings;
    private bool placeSettingsOpen = false;

    public Color activeColor;
    public Color inactiveColor;

    private void Start()
    {
        // Lowers the map so that the directions line doesn't flicker
        GameObject.Find("Map").transform.position = new Vector3(0f, -0.1f, 0f);
    }

    public void karttaButton()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Info"));

        paikat.SetActive(false);
        placeSettingsOpen = false;
        placeSettings.SetActive(false);
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




    public void Route()
    {
        var route = Instantiate(directions);
        cancelRouteButton.SetActive(true);
    }

    public void CancelRoute()
    {
        cancelRouteButton.SetActive(false);

        // finds the direction waypoints and destroys them
        GameObject[] dirArr = GameObject.FindGameObjectsWithTag("Directions");
        foreach (var dir in dirArr)
        {
            Destroy(dir);
        }

        // finds the direction line and destroys it
        Destroy(GameObject.Find("direction waypoint  entity"));

        // destroys the big info in paikat
        Destroy(activeObject);

        Destroy(GameObject.Find("DirectionsInfo(Clone)"));
    }

    public void OpenProfile()
    {
        profilePage.SetActive(true);
        profilePage.GetComponent<BerryUpdater>().UpdateAmount();
    }

    public void CloseProfile()
    {
        profilePage.SetActive(false);
        characterSelect.SetActive(false);
        OpenCharacterPage();
    }

    public void OpenCharacterPage()
    {
        characterBackground.SetActive(true);
        characterBottomBar.SetActive(true);
        advancementsBottomBar.SetActive(false);
    }

    public void OpenAdvancementsPage()
    {
        characterBackground.SetActive(false);
        characterBottomBar.SetActive(false);
        advancementsBottomBar.SetActive(true);
    }

    public void OpenPlaceSettings()
    {
        if (placeSettingsOpen == false)
        {
            placeSettingsOpen = true;
            placeSettings.SetActive(true);
        }
        else if (placeSettingsOpen == true)
        {
            placeSettingsOpen = false;
            placeSettings.SetActive(false);
        }
    }

    public void OpenCharacterSelect()
    {
        if (characterSelectOpen == false)
        {
            characterSelectOpen = true;
            characterSelect.SetActive(true);
        }
        else if (characterSelectOpen == true)
        {
            characterSelectOpen = false;
            characterSelect.SetActive(false);
        }
    }
}
