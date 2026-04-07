using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeScript : MonoBehaviour
{
    public TMP_InputField inputField;
    private string input;

    void Start()
    {
        inputField.onValueChanged.AddListener(SetInputString);
    }

    public void SetInputString(string s)
    {
        input = s;
        Debug.Log("The input is " + input);
    }
}
