using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DailyBerry : MonoBehaviour, IPointerDownHandler
{
    private DailyMinigame dailyMinigame;

    [SerializeField] private GameObject berryDie;
    private void Start()
    {
        dailyMinigame = GameObject.Find("DailyMinigame(Clone)").GetComponent<DailyMinigame>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dailyMinigame.berryAmount--;
        PlayerPrefs.SetInt("Berry", PlayerPrefs.GetInt("Berry", 0) + 1);
        dailyMinigame.berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();

        var die = Instantiate(berryDie, GameObject.Find("MinigameBush").transform);
        die.transform.localPosition = gameObject.transform.localPosition;
        die.transform.localScale = gameObject.transform.localScale;
        Destroy(die, 0.5f);

        Destroy(gameObject);
    }
}
