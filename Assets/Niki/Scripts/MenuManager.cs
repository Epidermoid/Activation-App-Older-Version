using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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
    }

    public void CloseProfile()
    {
        profilePage.SetActive(false);
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
}
