using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private string type;

    [SerializeField] private int id;

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
    }

}
