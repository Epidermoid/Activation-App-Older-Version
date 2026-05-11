using System.Collections;
using System.Collections.Generic;
using Mapbox.Map;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{


    public GameObject mapNotif;
    public GameObject profNotif;

    public GameObject[] unclaimed;
    public GameObject[] claimed;


    

    // Start is called before the first frame update
    void Start()
    {
        CheckUncheckedNotifs();

        
    }


    public void CheckUncheckedNotifs()
    {
        if (PlayerPrefs.GetInt("Unclaimed", 0) < 1)
        {
            mapNotif.SetActive(false);
            profNotif.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Unclaimed", 0) >= 1)
        {
            mapNotif.SetActive(true);
            profNotif.SetActive(true);
        }
    }
}
