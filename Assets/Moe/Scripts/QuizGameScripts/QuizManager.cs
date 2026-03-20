using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;


    public string catagory; // The category of the quiz game
    public static string SelectedCategory;
    [SerializeField] private QuizGameData quizGamesData; // Reference to the ScriptableObject containing quiz data
    [SerializeField] private List<QuizGameData.QuizData> currentQuizData; // List to hold the quiz data for the selected category
    public int currentQuizIndex; // Index to track the current category

    public TMPro.TextMeshProUGUI QuestionText;
    public TextMeshProUGUI scoreText;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    int totalQuestions;
    public int score;

    private void Awake()
    {
        if(Instance == null)
        {
           Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    void LoadCategory()
    {
        foreach (var cat in quizGamesData.data)
        {
            if (cat.catagoryName == catagory)
            {
                currentQuizData = new List<QuizGameData.QuizData>(cat.quizData);
                return;
            }
        }

        Debug.LogError("Category not found: " + catagory);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        scoreText.text = score + "/" + totalQuestions;

        foreach(var cat in quizGamesData.data)
        {
            if (cat.catagoryName == catagory)
            {
                cat.itsBadge = true;
                Debug.Log("Badge unlocked for category: " + catagory);
                break;
            }
        }
    }

    private void Start()
    {
        catagory = SelectedCategory;
        LoadCategory();
        totalQuestions = currentQuizData.Count;
      GoPanel.SetActive(false);
      QuizPanel.SetActive(true);
      GenerateQuestion();
    }

    public void Correct()
    {
        score++;
        currentQuizData.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        currentQuizData.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for(int i= 0; i< options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentQuizData[currentQuestion].answers[i];

            if (currentQuizData[currentQuestion].answerIndex == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void GenerateQuestion()
    {
        if(currentQuizData.Count > 0)
        {
            currentQuestion = Random.Range(0, currentQuizData.Count);
            QuestionText.text = currentQuizData[currentQuestion].question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions!!");
            GameOver();
        }
    }
}
