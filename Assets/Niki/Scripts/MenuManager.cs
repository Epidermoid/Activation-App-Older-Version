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

    public bool routing = false;

    [SerializeField] private GameObject directions;

    public GameObject activeObject;

    [SerializeField] private GameObject profilePage;

    [SerializeField] private GameObject characterBottomBar;
    [SerializeField] private GameObject advancementsBottomBar;

    [SerializeField] private GameObject achievementsPage;

    [SerializeField] private GameObject characterSelect;
    [SerializeField] private bool characterSelectOpen = false;
    [SerializeField] private GameObject unlock;
    

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

    public Color litUp;
    public Color dark;

    private CustomizeManager customizeManager;
    private int cSelInt;

    [SerializeField] private Image pencil;
    [SerializeField] private Image guy;
    [SerializeField] private Image set;
    [SerializeField] private Color full;
    [SerializeField] private Color not;

    public GameObject[] schools;
    public GameObject[] shops;
    public GameObject[] health;
    public GameObject[] cafes;
    public GameObject[] jobs;
    public GameObject[] documentation;

    public bool mapOnTop = true;



    private void Start()
    {


        // Lowers the map so that the directions line doesn't flicker (directions dont work in build :((((()
        GameObject.Find("Map").transform.position = new Vector3(0f, -0.1f, 0f);

        mapOnTop = true;

        cName.text = PlayerPrefs.GetString("Name", "Nimi");
        customizeManager = GameObject.Find("-CustomizeManager").GetComponent<CustomizeManager>();
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[PlayerPrefs.GetInt("Avatar", 0)];
        cSelInt = PlayerPrefs.GetInt("Avatar", 0);

        // there has to be a better way to do this...
        schools = GameObject.FindGameObjectsWithTag("School");
        shops = GameObject.FindGameObjectsWithTag("Shop");
        health = GameObject.FindGameObjectsWithTag("Health");
        cafes = GameObject.FindGameObjectsWithTag("Cafe");
        jobs = GameObject.FindGameObjectsWithTag("Job");
        documentation = GameObject.FindGameObjectsWithTag("Documentation");
    }

    public void karttaButton()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Info"));

        paikat.SetActive(false);
        placeSettingsOpen = false;
        placeSettings.SetActive(false);

        mapOnTop = true;

        AudioManager.PlayPop();
    }
    public void karttaButtonNoDestroy()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);

        paikat.SetActive(false);

        mapOnTop = true;

        
    }



    public void paikatButton()
    {
        karttaBottomBar.SetActive(false);
        paikatBottomBar.SetActive(true);

        paikat.SetActive(true);

        mapOnTop = false;

        AudioManager.PlayPop();
    }


    IEnumerator MakeRoute()
    {
        AudioManager.PlayPop();
        routing = true;
        //CancelRoute();
        yield return new WaitForSeconds(0.1f);
        var route = Instantiate(directions);

    }

    // Works in editor (even the simulator) but not in build for whatever reason
    public void Route()
    {
        if (!routing)
        StartCoroutine(MakeRoute());
    }

    public void CancelRoute()
    {
        AudioManager.PlayPop();

        // finds the direction waypoints and destroys them
        GameObject[] dirArr = GameObject.FindGameObjectsWithTag("Directions");

        if (dirArr != null )
        {
            foreach (var dir in dirArr)
            {
                Destroy(dir);
            }
            Destroy(GameObject.Find("DirectionsInfo(Clone)"));
            // finds the direction line and destroys it
            Destroy(GameObject.Find("direction waypoint  entity"));

            // destroys the big info in paikat
            Destroy(activeObject);
        }
    }

    public void OpenProfile()
    {
        profilePage.SetActive(true);
        profilePage.GetComponent<BerryUpdater>().UpdateAmount();

        mapOnTop = false;

        AudioManager.PlayPop();
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
        achievementsPage.SetActive(false);

        characterBottomBar.SetActive(true);
        advancementsBottomBar.SetActive(false);

        AudioManager.PlayPop();
    }

    public void OpenAdvancementsPage()
    {
        achievementsPage.SetActive(true);

        characterBottomBar.SetActive(false);
        advancementsBottomBar.SetActive(true);

        AudioManager.PlayPop();
    }

    public void OpenPlaceSettings()
    {
        AudioManager.PlayPop();
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
        AudioManager.PlayPop();
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
        AudioManager.PlayPop();

        var cS = cSelInt - 1;
        
        if (cS < 0)
        {
            cS = customizeManager.bigAvatars.Count - 1;
        }

        Debug.Log(cS);
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];

        cSelInt = cS;

        if (PlayerPrefs.GetInt("AvatarUnlocked" + (cS + 1), 0) == 1)
        {
            unlock.SetActive(false);

            customizeManager.bigAvatarSlot.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
            customizeManager.mapAvatar.GetComponent<SpriteRenderer>().sprite = customizeManager.mapAvatars[cS];
            
            PlayerPrefs.SetInt("Avatar", cS);

            customizeManager.equipBigAvatar.GetComponent<Image>().color = litUp;

            Debug.Log("Unlocked");
        }
        else if (PlayerPrefs.GetInt("AvatarUnlocked" + (cS + 1), 0) == 0)
        {
            unlock.SetActive(true);
            customizeManager.equipBigAvatar.GetComponent<Image>().color = dark;
        }
    }

    public void CSelectScrollRight()
    {
        AudioManager.PlayPop();
        
        var cS = cSelInt + 1;

        if (cS > customizeManager.bigAvatars.Count - 1)
        {
            cS = 0;
        }

        Debug.Log(cS);
        customizeManager.equipBigAvatar.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];

        cSelInt = cS;

        if (PlayerPrefs.GetInt("AvatarUnlocked" + (cS + 1), 0) == 1)
        {
            unlock.SetActive(false);

            customizeManager.bigAvatarSlot.GetComponent<Image>().sprite = customizeManager.bigAvatars[cS];
            customizeManager.mapAvatar.GetComponent<SpriteRenderer>().sprite = customizeManager.mapAvatars[cS];
            
            PlayerPrefs.SetInt("Avatar", cS);

            customizeManager.equipBigAvatar.GetComponent<Image>().color = litUp;

            Debug.Log("Unlocked");
        }
        else if (PlayerPrefs.GetInt("AvatarUnlocked" + (cS + 1), 0) == 0)
        {
            unlock.SetActive(true);
            customizeManager.equipBigAvatar.GetComponent<Image>().color = dark;
        }
        
    }

    public void Unlock()
    {
        AudioManager.PlayPop();

        // when you have enough money
        if (PlayerPrefs.GetInt("Berry", 0) >= 1000)
        {
            unlock.SetActive(false);

            PlayerPrefs.SetInt("Berry", PlayerPrefs.GetInt("Berry", 0) - 100);

            PlayerPrefs.SetInt("AvatarUnlocked" + (cSelInt + 1), 1);

            customizeManager.bigAvatarSlot.GetComponent<Image>().sprite = customizeManager.bigAvatars[cSelInt];
            customizeManager.mapAvatar.GetComponent<SpriteRenderer>().sprite = customizeManager.mapAvatars[cSelInt];

            PlayerPrefs.SetInt("Avatar", cSelInt);

            customizeManager.equipBigAvatar.GetComponent<Image>().color = litUp;
        }
        
        // when you dont have enough money
        else if (PlayerPrefs.GetInt("Berry", 0) < 1000)
        {

        }

    }



    public void OpenNameEdit()
    {
        AudioManager.PlayPop();

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
        AudioManager.PlayPop();

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
