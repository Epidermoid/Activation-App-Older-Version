using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    private GameObject infoPrefab;

    private MenuManager menuManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");

        menuManager.paikatButton();

        // var infoTab = Instantiate(infoPrefab, GameObject.Find("Canvas").transform);
    }


}