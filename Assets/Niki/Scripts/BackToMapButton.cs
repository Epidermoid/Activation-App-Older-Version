using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMapButton : MonoBehaviour
{
    
    public void BackToMap()
    {
        PlayerPrefs.SetInt("MinigamesCompleted", PlayerPrefs.GetInt("MinigamesCompleted", 0) + 1);
        if (PlayerPrefs.GetInt("MinigamesCompleted", 0) == 1)
        {
            PlayerPrefs.SetInt("A0Pending", 1);
            PlayerPrefs.SetInt("Unclaimed", PlayerPrefs.GetInt("Unclaimed", 0) + 1);

        }

        if (PlayerPrefs.GetInt("MinigamesCompleted", 0) == 3)
        {
            PlayerPrefs.SetInt("A1Pending", 1);
            PlayerPrefs.SetInt("Unclaimed", PlayerPrefs.GetInt("Unclaimed", 0) + 1);

        }

        SceneManager.LoadScene("LocationBased");
    }
}
