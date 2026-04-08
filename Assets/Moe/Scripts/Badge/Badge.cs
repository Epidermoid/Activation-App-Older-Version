using UnityEngine;

public class Badge : MonoBehaviour
{
    public string badgeName; // Assign this in Inspector

    private void Start()
    {
        if (BadgeManager.Instance != null)
        {
            gameObject.SetActive(BadgeManager.Instance.IsBadgeUnlocked(badgeName));
            Debug.Log("Badge activated");
        }
        else
        {
            Debug.LogWarning("BadgeManager instance not found!");
            gameObject.SetActive(false);
        }
    }
}