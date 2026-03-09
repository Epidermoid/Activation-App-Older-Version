using UnityEngine;
using TMPro;
using UnityEngine.UI;

using System.Collections.Generic;

public class SearchingWord : MonoBehaviour
{

    public TextMeshProUGUI displayText;
    public Image crossLine;

    private string _word;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        GameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string word)
    {
        _word = word;
        displayText.text = _word;
    }

    private void CorrectWord(string word, List<int> squaeIndexes)
    {
        if(word == _word)
        {
            crossLine.gameObject.SetActive(true);
        }
    }
}
