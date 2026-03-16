using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions : MonoBehaviour
{
    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        //finds the player and the wanted destination and sets the direction checks as their children
        if (gameObject.name == "Dir1")
        {
            gameObject.transform.parent = GameObject.Find("PlayerTarget").transform;
            gameObject.transform.localPosition = Vector3.zero;
        }
        else if (gameObject.name == "Dir2")
        {
            gameObject.transform.parent = GameObject.Find("Canvas").GetComponent<MenuManager>().dirTarget.transform;
            gameObject.transform.localPosition = Vector3.zero;
        }
    }


}
