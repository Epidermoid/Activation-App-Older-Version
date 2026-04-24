using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



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
    [SerializeField] private GameObject bottomStuff;

    [SerializeField] private GameObject characterSelect;
    [SerializeField] private bool characterSelectOpen = false;
    

    [SerializeField] private GameObject nameEdit;
    [SerializeField] private bool nameEditOpen = false;
    [SerializeField] private TextMeshProUGUI cName;
    [SerializeField] private TextMeshProUGUI cEdit;

    [SerializeField] private GameObject settings;
    [SerializeField] private bool settingsOpen = false;

    [SerializeField] private GameObject placeSettings;
    private bool placeSettingsOpen = false;

    public Color activeColor;
    public Color inactiveColor;

    private CustomizeManager customizeManager;
    private int cSelInt;

    [SerializeField] private Image pencil;
    [SerializeField] private Image guy;
    [SerializeField] private Image set;
    [SerializeField] private Color full;
    [SerializeField] private Color not;

    private GameObject[] schools;
    private GameObject[] shops;
    private GameObject[] health;
    private GameObject[] cafes;

    private void Start()
    {
        // Lowers the map so that the directions line doesn't flicker (directions dont work in build :((((()
        GameObject.Find("Map").transform.position = new Vector3(0f, -0.1f, 0f);

        cName.text = PlayerPrefs.GetString("Name", "Nimi");
        customizeManager = GameObject.Find("-CustomizeManager").GetComponent<CustomizeManager>();
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[PlayerPrefs.GetInt("Avatar", 0)];
        cSelInt = PlayerPrefs.GetInt("Avatar", 0);

        schools = GameObject.FindGameObjectsWithTag("School");
        shops = GameObject.FindGameObjectsWithTag("Shop");
        health = GameObject.FindGameObjectsWithTag("Health");
        cafes = GameObject.FindGameObjectsWithTag("Cafe");
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



    // Works in editor (even the simulator) but not in build for whatever reason
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
        
        characterSelectOpen = false;
        customizeManager.equipBigAvatar.SetActive(false);
        customizeManager.bigAvatarSlot.SetActive(true);
        nameEditOpen = false;
        nameEdit.SetActive(false);
        settingsOpen = false;
        settings.SetActive(false);
        pencil.color = full;
        guy.color = full;
        set.color = full;
        OpenCharacterPage();
        karttaButton();
    }

    public void OpenCharacterPage()
    {
        characterBackground.SetActive(true);
        characterBottomBar.SetActive(true);
        bottomStuff.SetActive(true);
        advancementsBottomBar.SetActive(false);
        cName.gameObject.SetActive(true);
    }

    public void OpenAdvancementsPage()
    {
        characterBackground.SetActive(false);
        characterBottomBar.SetActive(false);
        bottomStuff.SetActive(false);
        advancementsBottomBar.SetActive(true);
        cName.gameObject.SetActive(false);
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
            customizeManager.equipBigAvatar.SetActive(true);
            customizeManager.bigAvatarSlot.SetActive(false);

            nameEditOpen = false;
            nameEdit.SetActive(false);

            settingsOpen = false;
            settings.SetActive(false);

            pencil.color = not;
            guy.color = full;
            set.color = not;
        }
        else if (characterSelectOpen == true)
        {
            characterSelectOpen = false;
            customizeManager.equipBigAvatar.SetActive(false);
            customizeManager.bigAvatarSlot.SetActive(true);

            pencil.color = full;
            guy.color = full;
            set.color = full;
        }
    }

    public void CSelectScrollLeft()
    {
        var cS = cSelInt - 1;
        
        if (cS < 0)
        {
            cS = customizeManager.bigAvatars.Count - 1;
        }

        Debug.Log(cS);
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
        customizeManager.bigAvatarSlot.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
        customizeManager.mapAvatar.GetComponent<SpriteRenderer>().sprite = customizeManager.mapAvatars[cS];
        cSelInt = cS;
        PlayerPrefs.SetInt("Avatar", cS);
    }

    public void CSelectScrollRight()
    {
        var cS = cSelInt + 1;

        if (cS > customizeManager.bigAvatars.Count - 1)
        {
            cS = 0;
        }

        Debug.Log(cS);
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
        customizeManager.bigAvatarSlot.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
        customizeManager.mapAvatar.GetComponent<SpriteRenderer>().sprite = customizeManager.mapAvatars[cS];
        cSelInt = cS;
        PlayerPrefs.SetInt("Avatar", cS);
    }



    public void OpenNameEdit()
    {
        if (nameEditOpen == false)
        {
            nameEditOpen = true;
            nameEdit.SetActive(true);

            characterSelectOpen = false;
            customizeManager.equipBigAvatar.SetActive(false);
            customizeManager.bigAvatarSlot.SetActive(true);

            settingsOpen = false;
            settings.SetActive(false);

            pencil.color = full;
            guy.color = not;
            set.color = not;
        }
        else if (nameEditOpen == true)
        {
            nameEditOpen = false;
            nameEdit.SetActive(false);

            pencil.color = full;
            guy.color = full;
            set.color = full;
        }
    }

    public void NameEdit(string name)
    {
        cName.text = name;
        PlayerPrefs.SetString("Name", name);
    }

    public void OpenSettings()
    {
        if (settingsOpen == false)
        {
            settingsOpen = true;
            settings.SetActive(true);

            nameEditOpen = false;
            nameEdit.SetActive(false);

            characterSelectOpen = false;
            customizeManager.equipBigAvatar.SetActive(false);
            customizeManager.bigAvatarSlot.SetActive(true);

            pencil.color = not;
            guy.color = not;
            set.color = full;
        }
        else if (settingsOpen == true)
        {
            settingsOpen = false;
            settings.SetActive(false);

            pencil.color = full;
            guy.color = full;
            set.color = full;
        }
    }
}
