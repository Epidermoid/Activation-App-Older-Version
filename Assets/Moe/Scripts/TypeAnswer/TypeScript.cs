using UnityEngine;
using TMPro;
using System.Collections;
public class TypeScript : MonoBehaviour
{
    [SerializeField] private TypeData typeData;   // Your ScriptableObject
    public TMP_InputField inputField;             // Player types answer here
    public TMP_Text questionText;                 // Display the question
    public TMP_Text feedbackText;                 // Optional: show Correct/Wrong
    public GameObject GameObject;

    public static string selectedCategory;        // Set this from category button

    private TypeData.QuestionData currentQuestion;
    private string input;

    [SerializeField] private GameObject backToMap; // marking additions made by me (niki)

    void Start()
    {
        GameObject.SetActive(false);
        LoadCategory(selectedCategory);

        if (currentQuestion != null)
        {
            questionText.text = currentQuestion.question;
        }

        inputField.onValueChanged.AddListener(SetInputString);
    }

    private void LoadCategory(string categoryName)
    {
        currentQuestion = typeData.data.Find(q => q.categoryName == categoryName);
        selectedCategory = categoryName; // Store selected category for later use

        if (currentQuestion == null)
        {
            Debug.LogError("No question found for category: " + categoryName);
            questionText.text = "Question not found!";
        }
    }

    public void SetInputString(string s)
    {
        input = s;
        Debug.Log("Current input: " + input);
    }

    public void SubmitAnswer()
    {
        if (currentQuestion == null) return;

        string playerAnswer = input.Trim().ToLower();
        string correctAnswer = currentQuestion.answer.Trim().ToLower();

        if (playerAnswer == correctAnswer)
        {
            backToMap.SetActive(true); // marking additions made by me (niki)

            Debug.Log("Correct!");
            GameObject.SetActive(true);
            feedbackText.text = "Correct!";
            Debug.Log("Unlocking badge for category: " + selectedCategory);
            BadgeManager.Instance.UnlockBadge(selectedCategory); // Show badge for this category
            StartCoroutine(HideFeedbackAfterDelay(2f)); // Hide feedback after 2 seconds
            // Optionally, you could disable input after answer:

            inputField.interactable = false;
        }
        else
        {
            Debug.Log("Wrong! Correct answer was: " + correctAnswer);
            GameObject.SetActive(true);
            feedbackText.text = "Wrong Answer!!Try Again";
            StartCoroutine(HideFeedbackAfterDelay(2f)); // Hide feedback after 2 seconds

        }

    }
    private IEnumerator HideFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.SetActive(false);
    }
}
