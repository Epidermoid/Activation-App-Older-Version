using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyManager : MonoBehaviour
{
    [SerializeField] private string dateThen;
    [SerializeField] private string dateNow;
    public bool dailyDone;

    [SerializeField] private GameObject dailyEvent;

    // Start is called before the first frame update
    void Start()
    {
        

        dateThen = PlayerPrefs.GetString("DateThen", "a");
        dateNow = DateTime.Now.Date.ToString();

        if (dateNow == dateThen && PlayerPrefs.GetInt("DD", 0) == 1)
        {

            PlayerPrefs.SetString("DateThen", DateTime.Now.Date.ToString());
            Debug.Log("No");
        }
        else if (dateNow != dateThen || PlayerPrefs.GetInt("DD", 0) == 0)
        {

            PlayerPrefs.SetString("DateThen", DateTime.Now.Date.ToString());
            Debug.Log("Ye");
            
            dailyDone = false;
            PlayerPrefs.SetInt("DD", 0);
            StartCoroutine(DailyDelay());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            StartCoroutine(DailyDelay());
        }
    }

    IEnumerator DailyDelay()
    {
        yield return new WaitForSeconds(5f);

        var randomX = UnityEngine.Random.Range(-30, 30);
        var randomZ = UnityEngine.Random.Range(-30, 30);
        
        var playerX = GameObject.Find("PlayerTarget").transform.position.x;
        var playerZ = GameObject.Find("PlayerTarget").transform.position.z;

        var daily = Instantiate(dailyEvent, new Vector3(playerX + randomX, 5f, playerZ + randomZ), gameObject.transform.rotation);

    }
}
