using System.Net.Mime;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPuzzleButton : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData levelData;
    public TextMeshProUGUI catagoryText;
    public Image progressBarFilling;

    private string gameSceneName = "Word"; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        button.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonClick()
    {
        gameData.selectedCatagoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
