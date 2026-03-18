using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectQuizButton : MonoBehaviour
{
    public QuizGameData quizData;
    public GameObject buttonObject; // Reference to the button GameObject
    private string quizSceneName = "Quiz"; // The name of the quiz scene to load

    void Start()
    {
        var button = GetComponent<Button>();
        button.interactable = true;
    }

    public void OnCatagoryButtonClicked()
    {
        string catagoryName = gameObject.name; // Assuming the button's name corresponds to the category name
        foreach(var catagory in quizData.data)
        {
            if(catagory.catagoryName == catagoryName)
            {
                Debug.Log("Selected category: " + catagoryName);
                QuizManager.SelectedCategory = catagoryName; // Set the selected category in the QuizManager
                SceneManager.LoadScene(quizSceneName);
            }
        }
    }

   

}
