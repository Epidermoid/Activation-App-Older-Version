using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCardCategoryButton : MonoBehaviour
{
    public CardGameData cardGameData; // reference to ScriptableObject
    public string cardSceneName = "CardGameScene"; // scene with CardController

    void Start()
    {
        var button = GetComponent<Button>();
        button.interactable = true;
    }

    public void OnCategoryButtonClicked()
    {
        string categoryName = gameObject.name; // button name = category name
        foreach (var category in cardGameData.categories)
        {
            if (category.categoryName == categoryName)
            {
                Debug.Log("Selected category: " + categoryName);
                CardController.SelectedCategory = categoryName; // store selection
                SceneManager.LoadScene(cardSceneName);
                return;
            }
        }

        Debug.LogError("Category not found: " + categoryName);
    }
}