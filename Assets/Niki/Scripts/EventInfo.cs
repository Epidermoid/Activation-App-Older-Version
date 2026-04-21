using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] private GameObject codeInput;
    [SerializeField] private bool codeOpen;
    [SerializeField] private string correctCode;

    [SerializeField] private string mgCatagory;
    [SerializeField] private string mgScene;

    private MenuManager menuManager;

    private GameObject player;

    [SerializeField] private Button insertCodeButton;
    [SerializeField] private GameObject tooFarText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerTarget");

        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        linkedMarker = GameObject.Find(linkedMarker.name + "(Clone)");


        title.text = wantedTitle;
        basicInfo.text = "Osoite: " + address + "\nAukioloaika: " + times;
        longInfo.text = wantedInfo;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, linkedMarker.transform.position);

        if (distance <= 50f)
        {
            insertCodeButton.interactable = true;
            tooFarText.SetActive(false);
        }
        else if (distance > 50f)
        {
            insertCodeButton.interactable = false;
            tooFarText.SetActive(true);
        }
    }

    public void BackButton()
    {
        Destroy(gameObject);
    }

    public void GoButton()
    {
        // Changes the objects tag from info to active so that it's not destroyed by closing the paikat menu
        gameObject.tag = "Active";
        menuManager.karttaButtonNoDestroy();

        // instatiates the UI element that tells you where you are going
        var directions = Instantiate(dir, GameObject.Find("DirSpot").transform);

        directions.gameObject.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title.text;

        menuManager.activeObject = gameObject;

        menuManager.dirTarget = linkedMarker;
        
        menuManager.Route();
        
    }

    public void OpenCode()
    {
        if (codeOpen == false)
        {
            codeInput.SetActive(true);
            codeOpen = true;
        }
        else if (codeOpen == true)
        {
            codeInput.SetActive(false);
            codeOpen = false;
        } 
        
    }
    


    public void PlayMinigame()
    {
        QuizManager.SelectedCategory = mgCatagory;
        SceneManager.LoadScene(mgScene);
    }

    public void CheckCode(string input)
    {
        if (input == correctCode)
        {
            PlayMinigame();
        }
    }
}
