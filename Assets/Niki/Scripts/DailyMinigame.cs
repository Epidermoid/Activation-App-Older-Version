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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            var randomX = Random.Range(-30, 30);
            var randomZ = Random.Range(-30, 30);

            var bb = Instantiate(berry, GameObject.Find("MinigameBush").transform);
            bb.transform.localPosition = new Vector3 (randomX, randomZ, 0);
        }

        berryText.text = PlayerPrefs.GetInt("Berry", 0).ToString();
    }

    private void Update()
    {
        if (berryAmount == 0)
        {
            StartCoroutine(End());
        }
    }

    IEnumerator End()
    {
        animator.Play("Wow");
        yield return new WaitForSeconds(2f);
        GameObject.Find("Canvas").GetComponent<MenuManager>().karttaButton();
        PlayerPrefs.SetInt("DD", 1);
        Destroy(gameObject);
    }
}
