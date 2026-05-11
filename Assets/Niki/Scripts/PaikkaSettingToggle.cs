using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaikkaSettingToggle : MonoBehaviour
{
    [SerializeField] private Sprite active;
    [SerializeField] private Sprite inactive;
    [SerializeField] private Image set;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private bool on = true;

    
    [SerializeField] private GameObject setObject;

    [SerializeField] GameObject[] eventsInCategory;

    private MenuManager menuManager;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        // not a fan of this but it has to do for now ig
        if (gameObject.tag == "School")
        {
            eventsInCategory = menuManager.schools;
        }
        else if (gameObject.tag == "Shop")
        {
            eventsInCategory = menuManager.shops;
        }
        else if (gameObject.tag == "Health")
        {
            eventsInCategory = menuManager.health;
        }
        else if (gameObject.tag == "Cafe")
        {
            eventsInCategory = menuManager.cafes;
        }
        else if (gameObject.tag == "Job")
        {
            eventsInCategory = menuManager.jobs;
        }
        else if (gameObject.tag == "Documentation")
        {
            eventsInCategory = menuManager.documentation;
        }
    }

    public void PlaceToggle()
    {
        AudioManager.PlayPop();
        if (!setObject.activeSelf)
        {
            setObject.SetActive(true);


            set.sprite = active;
            text.color = menuManager.activeColor;

            foreach (GameObject e in eventsInCategory)
            {
                e.SetActive(true);
            }
        }
        else if (setObject.activeSelf)
        {
            setObject.SetActive(false);


            set.sprite = inactive;
            text.color = menuManager.inactiveColor;

            foreach (GameObject e in eventsInCategory)
            {
                e.SetActive(false);
            }
        }
    }
}
