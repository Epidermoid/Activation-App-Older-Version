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
        Destroy(gameObject);
    }
}
