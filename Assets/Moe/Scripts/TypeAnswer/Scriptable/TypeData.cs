using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class TypeData : ScriptableObject
{
    [System.Serializable]
    public class QuestionData
    {
        public string catagoryName;
        public string question;
        public string answer;
    }

    public List<QuestionData> data;
}
