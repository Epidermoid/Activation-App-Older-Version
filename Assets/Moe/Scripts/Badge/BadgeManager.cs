using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BadgeManager : MonoBehaviour
{
    public static BadgeManager Instance;

    private HashSet<string> unlockedBadges = new HashSet<string>();

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            savePath = Application.persistentDataPath + "/save.json";

            LoadGame(); // Load when game starts
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockBadge(string badgeName)
    {
        if (!unlockedBadges.Contains(badgeName))
        {
            unlockedBadges.Add(badgeName);
            Debug.Log("Badge unlocked: " + badgeName);

            SaveGame(); // Save immediately
        }
    }

    public bool IsBadgeUnlocked(string badgeName)
    {
        return unlockedBadges.Contains(badgeName);
    }

    // 🔹 SAVE
    public void SaveGame()
    {
        BadgeData data = new BadgeData();
        data.unlockedBadges = new List<string>(unlockedBadges);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game Saved to: " + savePath);
    }

    // 🔹 LOAD
    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            BadgeData data = JsonUtility.FromJson<BadgeData>(json);

            unlockedBadges = new HashSet<string>(data.unlockedBadges);

            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }
}