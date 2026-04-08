using UnityEngine;
using System.Collections;

public class Badge : MonoBehaviour
{
    public string badgeName;

    void Start()
    {
        bool unlocked = BadgeManager.Instance.IsBadgeUnlocked(badgeName);
        if(unlocked)
        {        
        gameObject.SetActive(true);
        Debug.Log("The bool is " + unlocked);
        } 
        else
        {
            gameObject.SetActive(false);
        }
    }
}