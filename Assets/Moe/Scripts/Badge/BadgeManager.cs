using System.Collections.Generic;
using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    public static BadgeManager Instance;
    private HashSet<string> unlockedBadges = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        }
    }

    public bool IsBadgeUnlocked(string badgeName)
    {
        return unlockedBadges.Contains(badgeName);
    }
}