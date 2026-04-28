using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyOnMap : MonoBehaviour
{
    [SerializeField] private GameObject minigame;
    private MenuManager menuManager;

    private void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

    private void OnMouseDown()
    {
        if (menuManager.mapOnTop)
        {
            var mg = Instantiate(minigame, GameObject.Find("Canvas").transform);
            Destroy(gameObject);
        }
            
    }
}
