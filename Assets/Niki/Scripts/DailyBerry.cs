using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DailyBerry : MonoBehaviour, IPointerDownHandler
{
    private DailyMinigame dailyMinigame;

    [SerializeField] private string type;

    [SerializeField] private GameObject berryDie;

    private AchievementManager achievementManager;
    private void Start()
    {
        dailyMinigame = GameObject.Find("DailyMinigame(Clone)").GetComponent<DailyMinigame>();
        achievementManager = GameObject.Find("-AchievementManager").GetComponent<AchievementManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.PlayPop();
        dailyMinigame.berryAmount--;
        PlayerPrefs.SetInt(type, PlayerPrefs.GetInt(type, 0) + 1);
        dailyMinigame.berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();
        dailyMinigame.berryRedText.text = PlayerPrefs.GetInt("RedBerry", 0).ToString();

        if (type == "GoldBerry")
        {
            if (PlayerPrefs.GetInt("A2Complete", 0) == 0 || PlayerPrefs.GetInt("A2Pending", 0) == 0)
            {
                PlayerPrefs.SetInt("A2Pending", 1);
                PlayerPrefs.SetInt("Unclaimed", PlayerPrefs.GetInt("Unclaimed", 0) + 1);

                achievementManager.CheckUncheckedNotifs();

                achievementManager.CheckPendingAndComplete();
            }
        }
        

        var die = Instantiate(berryDie, GameObject.Find("MinigameBush").transform);
        die.transform.localPosition = gameObject.transform.localPosition;
        die.transform.localScale = gameObject.transform.localScale;
        Destroy(die, 0.5f);

        Destroy(gameObject);
    }
}
