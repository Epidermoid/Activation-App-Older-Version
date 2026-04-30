using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailyMinigame : MonoBehaviour
{

    [SerializeField] private GameObject[] berrys;

    [SerializeField] public int berryAmount = 6;

    [SerializeField] public TextMeshProUGUI berryText;
    [SerializeField] public TextMeshProUGUI berryRedText;
    [SerializeField] public TextMeshProUGUI berryGoldText;


    [SerializeField] private Animator animator;

    [SerializeField] private GameObject goBackButton;
    [SerializeField] private GameObject areYouSure;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            var camera = Camera.main;
            var bounds = GameObject.Find("MinigameBush");

            Debug.Log(-bounds.GetComponent<RectTransform>().rect.width / 2 + (bounds.GetComponent<RectTransform>().sizeDelta.x / 2));

            var randomX = Random.Range(-60, 60);
            var randomZ = Random.Range(-60, 45);

            var randomBerryInt = Random.Range(0, 100);
            var rBerry = 0;
            if (randomBerryInt <= 20 && randomBerryInt >= 1)
            {
                rBerry = 1;
            }
            else if (randomBerryInt == 0)
            {
                rBerry = 2;
            }

            var bb = Instantiate(berrys[rBerry], bounds.transform);
            bb.transform.localPosition = new Vector3 (randomX, randomZ, 0);
        }

        berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();
        berryRedText.text = PlayerPrefs.GetInt("RedBerry", 0).ToString();
        berryGoldText.text = PlayerPrefs.GetInt("GoldBerry", 0).ToString();
        PlayerPrefs.SetInt("DD", 1);
    }

    private void Update()
    {
        if (berryAmount == 0)
        {
            berryAmount = -1;
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        goBackButton.SetActive(false);
        animator.Play("Wow");



        yield return new WaitForSeconds(2f);
        GameObject.Find("Canvas").GetComponent<MenuManager>().karttaButton();
        
        Destroy(gameObject);
    }

    public void GoBack()
    {
        areYouSure.SetActive(true);
    }

    public void No()
    {
        areYouSure.SetActive(false);
    }

    public void ExitMinigame()
    {
        Destroy(gameObject);
    }
}
