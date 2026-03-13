using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class QuizGameData : ScriptableObject
{
    [System.Serializable]
    public class QuizData
    {
        public string question;
        public string[] answers;
        public int answerIndex;
    }

    [System.Serializable]
    public class CatagoryData
    {
        public string catagoryName;
        public List<QuizData> quizData;
    }

    public List<CatagoryData> data;
}
