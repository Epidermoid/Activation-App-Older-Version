using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Mapbox.Map;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{


    public GameObject mapNotif;
    public GameObject profNotif;

    public GameObject[] notComplete;
    public GameObject[] unclaimed;
    public GameObject[] claimed;


    

    // Start is called before the first frame update
    void Start()
    {
        CheckUncheckedNotifs();

        CheckPendingAndComplete();
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

    public void CheckPendingAndComplete()
    {
        
        for(int i = 0; i <= notComplete.Length-1; i++)
        {
            Debug.Log(i);
        
        
            if (PlayerPrefs.GetInt("A" + i + "Completed", 0) == 1)
            {
                claimed[i].SetActive(true);
                unclaimed[i].SetActive(false);
                notComplete[i].SetActive(false);
            }
            else if (PlayerPrefs.GetInt("A" + i + "Pending", 0) == 1)
            {
                claimed[i].SetActive(false);
                unclaimed[i].SetActive(true);
                notComplete[i].SetActive(false);
            }
            else if (PlayerPrefs.GetInt("A" + i + "Pending", 0) == 0 && PlayerPrefs.GetInt("A" + i + "Completed", 0) == 0)
            {
                claimed[i].SetActive(false);
                unclaimed[i].SetActive(false);
                notComplete[i].SetActive(true);
            }
            
        }
        
    }
}
