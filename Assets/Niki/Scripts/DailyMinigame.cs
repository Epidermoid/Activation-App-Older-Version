using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailyMinigame : MonoBehaviour
{

    [SerializeField] private GameObject berry;

    [SerializeField] public int berryAmount = 6;

    [SerializeField] public TextMeshProUGUI berryText;

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

            var bb = Instantiate(berry, bounds.transform);
            bb.transform.localPosition = new Vector3 (randomX, randomZ, 0);
        }

        berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();
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

        PlayerPrefs.SetInt("Berry", PlayerPrefs.GetInt("Berry", 0) + 10);
        berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();

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
