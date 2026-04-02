using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyMinigame : MonoBehaviour
{

    [SerializeField] private GameObject berry;

    [SerializeField] public int berryAmount = 6;

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
    }

    private void Update()
    {
        if (berryAmount == 0)
        {
            Destroy(gameObject);
        }
    }

    private void End()
    {
        Destroy(gameObject);
    }
}
