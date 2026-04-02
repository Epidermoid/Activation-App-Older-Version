using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyOnMap : MonoBehaviour
{
    [SerializeField] private GameObject minigame;

    private void OnMouseDown()
    {
        var mg = Instantiate(minigame, GameObject.Find("Canvas").transform);
        Destroy(gameObject);
    }
}
