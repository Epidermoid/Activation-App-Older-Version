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

    private MenuManager menuManager;
    private void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

    public void PlaceToggle(GameObject wanted)
    {
        if (!wanted.activeSelf)
        {
            wanted.SetActive(true);
            set.sprite = active;
            text.color = menuManager.activeColor;
        }
        else if (wanted.activeSelf)
        {
            wanted.SetActive(false);
            set.sprite = inactive;
            text.color = menuManager.inactiveColor;
        }
    }
}
