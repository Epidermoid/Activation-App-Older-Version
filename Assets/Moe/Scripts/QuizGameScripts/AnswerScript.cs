using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            QuizManager.Instance.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            QuizManager.Instance.Wrong();
        }

    }
}
