using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRouteButton : MonoBehaviour
{
    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }


    public void CancelRoute()
    {
        var a = GameObject.Find("direction waypoint  entity");

        if (a != null)
        {
            // finds the direction waypoints and destroys them
            GameObject[] dirArr = GameObject.FindGameObjectsWithTag("Directions");

            if (dirArr != null)
            {
                foreach (var dir in dirArr)
                {
                    Destroy(dir);
                }

                // finds the direction line and destroys it
                Destroy(a);

                // destroys the big info in paikat
                Destroy(menuManager.activeObject);

                menuManager.routing = false;

                Destroy(gameObject);
            }

        
        }
    }
}
