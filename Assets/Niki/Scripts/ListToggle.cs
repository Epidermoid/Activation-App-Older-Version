using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListToggle : MonoBehaviour
{
    private bool toggle = false;

    [SerializeField] private GameObject down;
    [SerializeField] private GameObject up;

    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    public void Toggle()
    {
        // the toggle in lists. the button itself is invisible
        if (!toggle)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
            }
            down.SetActive(false);
            up.SetActive(true);

            toggle = true;
        }
        else if (toggle)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            }
            down.SetActive(true);
            up.SetActive(false);

            toggle = false;
        }
    }
}
