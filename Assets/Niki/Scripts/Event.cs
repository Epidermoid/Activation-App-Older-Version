using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPrefab;

    private MenuManager menuManager;

    private AudioManager audioManager;

    [SerializeField] private SpriteRenderer iconSlot;
    [SerializeField] private Sprite wantedIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iconSlot.sprite = wantedIcon;

        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
    }

    private void OnMouseDown()
    {
        if (menuManager.mapOnTop)
        {
            AudioManager.PlayPop();

            menuManager.paikatButton();

            var infoTab = Instantiate(infoPrefab, GameObject.Find("PaikatList").transform);
        }
        
    }


}