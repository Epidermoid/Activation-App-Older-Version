using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DailyBerry : MonoBehaviour, IPointerDownHandler
{
    private DailyMinigame dailyMinigame;
    private void Start()
    {
        dailyMinigame = GameObject.Find("DailyMinigame(Clone)").GetComponent<DailyMinigame>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dailyMinigame.berryAmount--;
        PlayerPrefs.SetInt("Berry", PlayerPrefs.GetInt("Berry") + 1);
        dailyMinigame.berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();

        Destroy(gameObject);
    }
}
