using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private string type;

    [SerializeField] private int id;

    [SerializeField] private GameObject anim;
    

    private AchievementManager achievementManager;

    void Start()
    {
        achievementManager = GameObject.Find("-AchievementManager").GetComponent<AchievementManager>();
    }

    public void Claim()
    {
        AudioManager.PlayPop();
        PlayerPrefs.SetInt(type, PlayerPrefs.GetInt(type, 0) + value);
        PlayerPrefs.SetInt("Unclaimed", PlayerPrefs.GetInt("Unclaimed", 0) - 1);
        PlayerPrefs.SetInt("A" + id + "Pending", 0);
        PlayerPrefs.SetInt("A" + id + "Completed", 1);

        PlayerPrefs.SetInt(type, PlayerPrefs.GetInt(type) + value);

        var a = Instantiate(anim, GameObject.Find("Canvas").transform);
        
        var aP = a.GetComponent<AchievementAnimation>();
        aP.value.text = value.ToString();
        if (type == "Berry")
        {
            aP.image.sprite = aP.sprites[0];
        }
        else if (type == "RedBerry")
        {
            aP.image.sprite = aP.sprites[1];
        }
        else if (type == "GoldBerry")
        {
            aP.image.sprite = aP.sprites[2];
        }
        Destroy(a, 1.32f); 

        achievementManager.CheckUncheckedNotifs();
        achievementManager.CheckPendingAndComplete();
    }

}
