using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMapButton : MonoBehaviour
{
    
    public void BackToMap()
    {
        SceneManager.LoadScene("LocationBased");
    }
}
