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

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        scoreText.text = score + "/" + totalQuestions;
    }

    private void Start()
    {
      totalQuestions = QnA.Count;
      GoPanel.SetActive(false);
      QuizPanel.SetActive(true);
      GenerateQuestion();
    }

    public void Correct()
    {
        score++;
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for(int i= 0; i< options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent <AnswerScript>().isCorrect = true;
            }
        }
    }
    void GenerateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions!!");
            GameOver();
        }
    }
}
