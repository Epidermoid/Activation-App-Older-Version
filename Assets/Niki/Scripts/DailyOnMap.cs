using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyOnMap : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    private MenuManager menuManager;
    private AudioManager audioManager;

    private void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
    }

    private void OnMouseDown()
    {
        if (menuManager.mapOnTop)
        {
            AudioManager.PlayPop();
            var mg = Instantiate(minigame, GameObject.Find("Canvas").transform);
            Destroy(gameObject);
        }
            
    }
}
