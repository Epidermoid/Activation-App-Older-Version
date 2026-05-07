using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListToggle : MonoBehaviour
{
    private bool toggle = false;


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


            toggle = true;
        }
        else if (toggle)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            }


            toggle = false;
        }
    }
}
