using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectTypeButton : MonoBehaviour
{
    public TypeData typeData; // reference to ScriptableObject
    public string cardSceneName = "CardGameScene"; // scene with CardController

    void Start()
    {
        var button = GetComponent<Button>();
        button.interactable = true;
    }

    public void OnCategoryButtonClicked()
    {
        string categoryName = gameObject.name; // button name = category name
        foreach (var category in typeData.data)
        {
            if (category.categoryName == categoryName)
            {
                Debug.Log("Selected category: " + categoryName);
                TypeScript.selectedCategory = categoryName; // store selection
                SceneManager.LoadScene(cardSceneName);
                return;
            }
        }

        Debug.LogError("Category not found: " + categoryName);
    }
}
